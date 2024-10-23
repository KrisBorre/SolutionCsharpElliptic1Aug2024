using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsButcherExercise20point1_30Aug2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsButcherExercise20point1_Crude30Aug2024
{
    internal class ControlManager
    {
        private PlotView plotView;

        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        public ControlManager(int width, int height)
        {
            /*
            Comparison between crude Runge-Kutta calculation and sophisticated Runge-Kutta calculation. 
            The graph shows the numerical error of the calculation as a function of the stepsize for both, crude(orange) and sophisticated(blue).
            You read this graph from top-left to bottom-right.
            With a large stepsize the numerical error on the solution decreases when the stepsize is reduced.
            As the stepsize decreases the numerical error gets smaller until it reaches machine-epsilon using sophisticated Runge-Kutta.

            When we use a Runge-Kutta algorithm -- which I call crude Runge-Kutta -- and continue to lower the stepsize in an attempt to improve the accuracy of the result, the accumulation of the numerical error starts to dominate over the solution, rendering our computational effort worthless. 
            We can study this pathological behaviour when we use a system of differential equations that we can solve analytically.            
            The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.

            An Euler method or a higher order method, like Runge-Kutta, will both have a similar accumulation error for a certain stepsize.
            We can correct for this accumulation of numerical errors and I call this method sophisticated Runge-Kutta.

            Reference: Numerical methods for ODEs, Butcher(2008)
            */

            plotView = new PlotView();

            PlotModel plotModel = new PlotModel();

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Sophisticated RK (without accumulation of numerical errors)" };
            LineSeries series2 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Crude RK (with accumulation of numerical errors)" };

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.5, -12), Text = "Many steps" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-2.5, -5), Text = "Few steps" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.5, -14), Text = "Accurate" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-2, -7), Text = "Inaccurate" });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-3, -14.7), Text = "Log10(delta_x)" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.8, -9), Text = "Log10(abs(error))" });

            plotView.Location = new Point(0, 0);

            const int kmax = 12; // 15; 

            Console.WriteLine("Solver with Flags enum");
            var butcher = new DifferentialEquationsButcherExercise20point1_30Aug2024<double>();
            int numberOfFirstOrderEquations = butcher.NumberOfFirstOrderEquations;
            ISolver26feb2024<double> solver1 = new DifferentialEquationsSolver26feb2024<double>(butcher, Method.RK41 | Method.Sophisticated);
            ISolver26feb2024<double> solver2 = new DifferentialEquationsSolver26feb2024<double>(butcher, Method.RK41 | Method.Crude);

            double interval = Math.PI;

            double initial_y = 0.5;
            double C = 1.0 / initial_y; // 2
            double y1_initial = y1_exact_function(0, C); // 0.5

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                     y1_exact_function(0, C));
            //ic.X = 0;

            ulong number_of_steps = 200;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                solver1.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solution: out NumericalSolution8apr2024<double> solutionSophisticated, interval: interval, x_end: interval);

                solver2.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_crude, solution: out NumericalSolution8apr2024<double> solutionCrude, interval: interval, x_end: interval);

                double y1_pi_exact = y1_exact_function(Math.PI, C);

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

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                double error_crude = sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2));
                Console.WriteLine("error_crude = " + error_crude);

                series1.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_sophisticated))));
                series2.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_crude))));

                number_of_steps *= 2;
            }

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            this.plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            this.plotView.Size = new Size(width - 50, height - 50);

            this.plotView.Model = plotModel;
            this.controls = new List<Control>();
            Controls.Add(plotView);
        }


        static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        static double abs(double x)
        {
            return Math.Abs(x);
        }

        static double exp(double x)
        {
            return Math.Exp(x);
        }

        static double sin(double x)
        {
            return Math.Sin(x);
        }

        static double cos(double x)
        {
            return Math.Cos(x);
        }

        static double y1_exact_function(double x, double C)
        {
            return (1 + x) / (C + x * x);
        }
    }
}
