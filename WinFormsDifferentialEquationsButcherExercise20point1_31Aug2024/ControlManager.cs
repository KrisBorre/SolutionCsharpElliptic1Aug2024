using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsButcherExercise20point1_30Aug2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsDifferentialEquationsButcherExercise20point1_31Aug2024
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

            var problem = new DifferentialEquationsButcherExercise20point1_30Aug2024<double>();

            var solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RKCV8);

            double initial_y = 0.5;
            double C = 1.0 / initial_y; // 2
            double y1_initial = y1_exact_function(0, C); // 0.5

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                     y1_exact_function(0, C));
            //ic.X = 0;

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

            LineSeries series1 = new LineSeries { Title = "(1 + x) / (2 + x^2)" };

            for (int i = 0; i < solutions.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions[i];
                series1.Points.Add(new DataPoint(solution.X, solution.Y[0]));
            }

            plotModel.Series.Add(series1);

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.BottomLeft,
            });
        }

        static double y1_exact_function(double x, double C)
        {
            return (1 + x) / (C + x * x);
        }
    }
}
