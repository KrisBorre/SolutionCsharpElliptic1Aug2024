using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsLotkaVolterra16Aug2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsLotkaVolterraOrbit17Aug2024
{
    internal class ControlManager
    {
        public PlotView PlotView1;

        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            this.PlotView1 = new PlotView();

            this.PlotView1.Size = new Size(width, height - 40);
            this.PlotView1.Location = new Point(0, 40);

            Controls.Add(PlotView1);

            this.Calculate();
        }

        private void Calculate()
        {
            double interval = 2.0 * Math.PI;

            ulong number_of_steps = 200;

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsLotkaVolterra16Aug2024<double>(), Method.RK61 | Method.Sophisticated);

            // (u_0, v_0) = (2, 2)
            ConditionInitial26feb2024<double> ic1 = new ConditionInitial26feb2024<double>(0,
                                           2,
                                           2);

            // (u_0, v_0) = (3, 2)
            ConditionInitial26feb2024<double> ic2 = new ConditionInitial26feb2024<double>(0,
                                           3,
                                           2);

            // (u_0, v_0) = (2.5, 2)
            ConditionInitial26feb2024<double> ic3 = new ConditionInitial26feb2024<double>(0,
                                           2.5,
                                           2);

            solver.Solve(initialCondition: ic1, number_of_steps: number_of_steps, delta_x: out double delta_x_1, solutions: out NumericalSolutions26feb2024<double> solutions1, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);

            solver.Solve(initialCondition: ic2, number_of_steps: number_of_steps, delta_x: out double delta_x_2, solutions: out NumericalSolutions26feb2024<double> solutions2, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);

            solver.Solve(initialCondition: ic3, number_of_steps: number_of_steps, delta_x: out double delta_x_3, solutions: out NumericalSolutions26feb2024<double> solutions3, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);


            PlotModel plotModel1 = new PlotModel();
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 5 });
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 5 });

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle };

            for (int i = 0; i < solutions1.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions1[i];
                series1.Points.Add(new DataPoint(solution.Y[0], solution.Y[1]));
            }

            plotModel1.Series.Add(series1);

            LineSeries series2 = new LineSeries { MarkerType = MarkerType.Circle };

            for (int i = 0; i < solutions2.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions2[i];
                series2.Points.Add(new DataPoint(solution.Y[0], solution.Y[1]));
            }

            plotModel1.Series.Add(series2);

            LineSeries series3 = new LineSeries { MarkerType = MarkerType.Circle };

            for (int i = 0; i < solutions3.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions3[i];
                series3.Points.Add(new DataPoint(solution.Y[0], solution.Y[1]));
            }

            plotModel1.Series.Add(series3);

            plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(1, 2), Text = "Lotka-Volterra Orbit" });

            this.PlotView1.Model = plotModel1;

        }
    }
}
