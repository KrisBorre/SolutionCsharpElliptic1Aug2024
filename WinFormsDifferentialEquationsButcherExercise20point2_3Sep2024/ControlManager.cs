using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsButcherExercise20point2_2Sep2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsDifferentialEquationsButcherExercise20point2_3Sep2024
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

            var problem = new DifferentialEquationsButcherExercise20point2_2Sep2024<double>();

            var solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RKCV8);

            double initial_y2 = 0.25;
            double C = 1.0 / initial_y2; // 4 
            double y2_initial = y2_exact_function(0, C); // 0.25

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0, 0, y2_exact_function(0, C));
            //ic.X = 0;

            double interval = 1.0;

            ulong number_of_steps = 1000;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);

            PlotView plotView = new PlotView();
            this.controls.Add(plotView);

            plotView.Size = new Size(width, height);
            plotView.Location = new Point(0, 0);
            plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            PlotModel plotModel = new PlotModel();
            plotView.Model = plotModel;

            LineSeries series1 = new LineSeries { Title = "(1 + x) / (4 + x^2)" };

            for (int i = 0; i < solutions.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions[i];
                series1.Points.Add(new DataPoint(solution.X, solution.Y[1]));
            }

            plotModel.Series.Add(series1);

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.LeftTop,
            });
        }

        static double y2_exact_function(double x, double C)
        {
            return (1 + x) / (C + x * x);
        }
    }
}
