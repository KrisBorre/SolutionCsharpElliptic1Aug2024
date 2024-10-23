using LibraryDifferentialEquations6apr2024;
using LibraryDifferentialEquationsLotkaVolterra16Aug2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsLotkaVolterra20Aug2024
{
    internal class ControlManager
    {
        public PlotView PlotView1;
        public PlotView PlotView2;

        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private Label label1;

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "The period T for (u_0, v_0) = (2, 2) is approx. 4.6";

            this.controls.Add(this.label1);

            this.PlotView1 = new PlotView();
            this.PlotView2 = new PlotView();

            int totalPlotViewheight = height - 40;

            this.PlotView1.Size = new Size(width, (totalPlotViewheight - 40) / 2);
            this.PlotView1.Location = new Point(0, 40);

            this.PlotView2.Size = new Size(width, (totalPlotViewheight - 40) / 2);
            this.PlotView2.Location = new Point(0, 40 + ((totalPlotViewheight - 40) / 2));

            Controls.Add(PlotView1);
            Controls.Add(PlotView2);

            this.Calculate();
        }

        private void Calculate()
        {
            double interval = 2.0 * Math.PI;

            ulong number_of_steps = 200;

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsLotkaVolterra16Aug2024<double>(), Method.RK61 | Method.Sophisticated);

            // (u_0, v_0) = (2, 2)
            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                           2,
                                           2);

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);

            #region solution.X is the time and solution.Y[0] is the X coordinate
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series3.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                }

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 2, 1), Text = "X coordinate" });

                this.PlotView1.Model = plotModel3;
            }
            #endregion

            #region solution.X is the time and solution.Y[1] is the Y coordinate
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series3.Points.Add(new DataPoint(solution.X, solution.Y[1]));
                }

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 2, 2), Text = "Y coordinate" });

                this.PlotView2.Model = plotModel3;
            }
            #endregion

        }
    }
}
