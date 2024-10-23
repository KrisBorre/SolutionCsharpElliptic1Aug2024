using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsKeplerNumericalTypes6apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerNumericalAccuracy7apr2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        public ControlManager(Size size)
        {
            this.controls = new List<Control>();

            PlotView plotView = new PlotView();
            PlotModel plotModel = new PlotModel();

            LineSeries seriesFloatSophisticated = new LineSeries { MarkerType = MarkerType.Circle, Title = "Float Sophisticated Euler (without accumulation of numerical errors)" };
            LineSeries seriesFloatCrude = new LineSeries { MarkerType = MarkerType.Circle, Title = "Float Crude RK22 (with accumulation of numerical errors)" };

            LineSeries seriesDoubleSophisticated = new LineSeries { MarkerType = MarkerType.Circle, Title = "Double Sophisticated RK31 (without accumulation of numerical errors)" };
            LineSeries seriesDoubleCrude = new LineSeries { MarkerType = MarkerType.Circle, Title = "Double Crude RK41 (with accumulation of numerical errors)" };

            LineSeries seriesDecimalSophisticated = new LineSeries { MarkerType = MarkerType.Circle, Title = "Decimal Sophisticated RK51 (without accumulation of numerical errors)" };
            LineSeries seriesDecimalCrude = new LineSeries { MarkerType = MarkerType.Circle, Title = "Decimal Crude RK61 (with accumulation of numerical errors)" };

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotView.Location = new Point(0, 0);

            {
                const int kmax = 17; // 15;

                const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
                Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

                Console.WriteLine("Solver with Flags enum");

                int numberOfFirstOrderEquations = 4;
                var solverFloatSophisticated = new DifferentialEquationsSolverNumericalType6apr2024(NumericalType12mar2024.Float, Method.Euler | Method.Sophisticated);
                var solverFloatCrude = new DifferentialEquationsSolverNumericalType6apr2024(NumericalType12mar2024.Float, Method.RK22 | Method.Crude);

                double interval = Math.PI;

                ulong number_of_steps = 25;

                for (int k = 0; k < kmax; k++)
                {
                    Console.WriteLine("number_of_steps = " + number_of_steps);

                    ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                             (double)DoubleHelper.y1_zero_exact_function(eccentricity),
                                                             (double)DoubleHelper.y2_zero_exact_function(eccentricity),
                                                             (double)DoubleHelper.y3_zero_exact_function(eccentricity),
                                                             (double)DoubleHelper.y4_zero_exact_function(eccentricity));
                    //ic.X = 0;

                    // T interval = T.CreateChecked(Math.PI) // default
                    // T x_end = T.CreateChecked(Math.PI) // default
                    double x_end = Math.PI;

                    solverFloatSophisticated.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, out NumericalSolution8apr2024<double> solutionSophisticated);
                    solverFloatCrude.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_crude, out NumericalSolution8apr2024<double> solutionCrude);

                    double y1_pi_exact = DoubleHelper.y1_pi_exact_function(eccentricity);
                    double y2_pi_exact = DoubleHelper.y2_pi_exact_function(eccentricity);
                    double y3_pi_exact = DoubleHelper.y3_pi_exact_function(eccentricity);
                    double y4_pi_exact = DoubleHelper.y4_pi_exact_function(eccentricity);

                    double[] y_sophisticated = new double[numberOfFirstOrderEquations];
                    for (int i = 0; i < numberOfFirstOrderEquations; i++)
                    {
                        y_sophisticated[i] = solutionSophisticated.Y[i];
                    }

                    double[] y_crude = new double[numberOfFirstOrderEquations];
                    for (int i = 0; i < numberOfFirstOrderEquations; i++)
                    {
                        y_crude[i] = solutionCrude.Y[i];
                    }

                    double float_error_sophisticated = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                    Console.WriteLine("error_sophisticated = " + float_error_sophisticated);

                    double float_error_crude = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                    Console.WriteLine("error_crude = " + float_error_crude);

                    seriesFloatSophisticated.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(float_error_sophisticated))));
                    seriesFloatCrude.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(float_error_crude))));

                    number_of_steps *= 2;
                }
            }

            {
                const int kmax = 17; // 16; // 15;

                const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
                Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

                Console.WriteLine("Solver with Flags enum");

                int numberOfFirstOrderEquations = 4;
                var solverDoubleSophisticated = new DifferentialEquationsSolverNumericalType6apr2024(NumericalType12mar2024.Double, Method.RK31 | Method.Sophisticated);
                var solverDoubleCrude = new DifferentialEquationsSolverNumericalType6apr2024(NumericalType12mar2024.Double, Method.RK41 | Method.Crude);

                double interval = Math.PI;

                ulong number_of_steps = 25;

                for (int k = 0; k < kmax; k++)
                {
                    Console.WriteLine("number_of_steps = " + number_of_steps);

                    ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                             (double)DoubleHelper.y1_zero_exact_function(eccentricity),
                                                             (double)DoubleHelper.y2_zero_exact_function(eccentricity),
                                                             (double)DoubleHelper.y3_zero_exact_function(eccentricity),
                                                             (double)DoubleHelper.y4_zero_exact_function(eccentricity));
                    //ic.X = 0;

                    // T interval = T.CreateChecked(Math.PI) // default
                    // T x_end = T.CreateChecked(Math.PI) // default
                    double x_end = Math.PI;

                    solverDoubleSophisticated.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, out NumericalSolution8apr2024<double> solutionSophisticated);
                    solverDoubleCrude.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_crude, out NumericalSolution8apr2024<double> solutionCrude);

                    double y1_pi_exact = DoubleHelper.y1_pi_exact_function(eccentricity);
                    double y2_pi_exact = DoubleHelper.y2_pi_exact_function(eccentricity);
                    double y3_pi_exact = DoubleHelper.y3_pi_exact_function(eccentricity);
                    double y4_pi_exact = DoubleHelper.y4_pi_exact_function(eccentricity);

                    double[] y_sophisticated = new double[numberOfFirstOrderEquations];
                    for (int i = 0; i < numberOfFirstOrderEquations; i++)
                    {
                        y_sophisticated[i] = solutionSophisticated.Y[i];
                    }

                    double[] y_crude = new double[numberOfFirstOrderEquations];
                    for (int i = 0; i < numberOfFirstOrderEquations; i++)
                    {
                        y_crude[i] = solutionCrude.Y[i];
                    }

                    double error_sophisticated = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                    Console.WriteLine("error_sophisticated = " + error_sophisticated);

                    double error_crude = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                    Console.WriteLine("error_crude = " + error_crude);

                    seriesDoubleSophisticated.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(error_sophisticated))));
                    seriesDoubleCrude.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(error_crude))));

                    number_of_steps *= 2;
                }
            }

            {
                const int kmax = 17; // 15; // 12; 

                const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
                Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

                Console.WriteLine("Solver with Flags enum");

                int numberOfFirstOrderEquations = 4;
                var solverDecimalSophisticated = new DifferentialEquationsSolverNumericalType6apr2024(NumericalType12mar2024.Decimal, Method.RK5 | Method.Sophisticated);
                var solverDecimalCrude = new DifferentialEquationsSolverNumericalType6apr2024(NumericalType12mar2024.Decimal, Method.RK61 | Method.Crude);

                double interval = Math.PI;

                ulong number_of_steps = 25;

                for (int k = 0; k < kmax; k++)
                {
                    Console.WriteLine("number_of_steps = " + number_of_steps);

                    ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                        (double)DoubleHelper.y1_zero_exact_function(eccentricity),
                                                        (double)DoubleHelper.y2_zero_exact_function(eccentricity),
                                                        (double)DoubleHelper.y3_zero_exact_function(eccentricity),
                                                        (double)DoubleHelper.y4_zero_exact_function(eccentricity));
                    //ic.X = 0;

                    // T interval = T.CreateChecked(Math.PI) // default
                    // T x_end = T.CreateChecked(Math.PI) // default
                    double x_end = Math.PI;

                    solverDecimalSophisticated.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, out NumericalSolution8apr2024<double> solutionSophisticated);
                    solverDecimalCrude.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_crude, out NumericalSolution8apr2024<double> solutionCrude);

                    decimal y1_pi_exact = DecimalHelper.y1_pi_exact_function((decimal)eccentricity);
                    decimal y2_pi_exact = DecimalHelper.y2_pi_exact_function((decimal)eccentricity);
                    decimal y3_pi_exact = DecimalHelper.y3_pi_exact_function((decimal)eccentricity);
                    decimal y4_pi_exact = DecimalHelper.y4_pi_exact_function((decimal)eccentricity);

                    decimal[] y_sophisticated = new decimal[numberOfFirstOrderEquations];
                    for (int i = 0; i < numberOfFirstOrderEquations; i++)
                    {
                        y_sophisticated[i] = (decimal)solutionSophisticated.Y[i];
                    }

                    decimal[] y_crude = new decimal[numberOfFirstOrderEquations];
                    for (int i = 0; i < numberOfFirstOrderEquations; i++)
                    {
                        y_crude[i] = (decimal)solutionCrude.Y[i];
                    }

                    decimal decimal_error_sophisticated = (decimal)DecimalHelper.sqrt((double)(((y1_pi_exact - y_sophisticated[0]) * (y1_pi_exact - y_sophisticated[0])) + ((y2_pi_exact - y_sophisticated[1]) * (y2_pi_exact - y_sophisticated[1])) + ((y3_pi_exact - y_sophisticated[2]) * (y3_pi_exact - y_sophisticated[2])) + ((y4_pi_exact - y_sophisticated[3]) * (y4_pi_exact - y_sophisticated[3]))));
                    Console.WriteLine("error_sophisticated = " + decimal_error_sophisticated);

                    decimal decimal_error_crude = (decimal)DecimalHelper.sqrt((double)(((y1_pi_exact - y_crude[0]) * (y1_pi_exact - y_crude[0])) + ((y2_pi_exact - y_crude[1]) * (y2_pi_exact - y_crude[1])) + ((y3_pi_exact - y_crude[2]) * (y3_pi_exact - y_crude[2])) + ((y4_pi_exact - y_crude[3]) * (y4_pi_exact - y_crude[3]))));
                    Console.WriteLine("error_crude = " + decimal_error_crude);

                    seriesDecimalSophisticated.Points.Add(new DataPoint(Math.Log10((double)delta_x), Math.Log10((double)DecimalHelper.abs(decimal_error_sophisticated))));
                    seriesDecimalCrude.Points.Add(new DataPoint(Math.Log10((double)delta_x), Math.Log10((double)DecimalHelper.abs(decimal_error_crude))));

                    number_of_steps *= 2;
                }
            }

            plotModel.Series.Add(seriesFloatSophisticated);
            plotModel.Series.Add(seriesFloatCrude);

            plotModel.Series.Add(seriesDoubleSophisticated);
            plotModel.Series.Add(seriesDoubleCrude);

            plotModel.Series.Add(seriesDecimalSophisticated);
            plotModel.Series.Add(seriesDecimalCrude);

            plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            plotView.Size = new Size(size.Width - 50, size.Height - 50);

            plotView.Model = plotModel;
            this.controls.Add(plotView);

        }

    }
}
