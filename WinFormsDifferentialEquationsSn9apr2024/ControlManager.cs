using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsSn9apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsDifferentialEquationsSn9apr2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            var problem = new DifferentialEquationsSn9apr2024<double>();

            var solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RKCV8);

            // u = 0
            // sn(0, k) = 0
            // cn(0, k) * dn(0, k) = 1
            var ic = new ConditionInitial26feb2024<double>(0,
                                           0.0,
                                           1.0);

            double interval = 5.0;

            ulong number_of_steps = 10000;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);

            PlotView plotView = new PlotView();
            this.controls.Add(plotView);

            plotView.Size = new Size(width, height);
            plotView.Location = new Point(0, 0);
            plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            PlotModel plotModel = new PlotModel();
            plotView.Model = plotModel;

            LineSeries series1 = new LineSeries { Title = "sn(u,k) with k=0.5" };
            LineSeries series2 = new LineSeries { Title = "derivative of sn" };

            for (int i = 0; i < solutions.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions[i];
                series1.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                series2.Points.Add(new DataPoint(solution.X, solution.Y[1]));
            }

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.BottomLeft,
            });
        }
    }
}
