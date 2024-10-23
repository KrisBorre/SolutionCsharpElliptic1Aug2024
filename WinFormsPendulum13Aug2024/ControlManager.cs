using LibraryDifferentialEquations6apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using LibraryPendulum16feb2024;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsPendulum13Aug2024
{
    internal class ControlManager
    {
        public PlotView PlotView1;

        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();

            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(1352, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            this.button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.button1.Location = new Point(1113, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            this.label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(1232, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "p_theta_max:";

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "Solving a system of differential equations: Pendulum.";

            this.PlotView1 = new PlotView();
            this.PlotView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            this.PlotView1.Size = new Size(1456, 557 - 40);
            this.PlotView1.Location = new Point(0, 40);

            // Hint use 1 and 2.
            // 1 will result in a sine function.
            // 2 will result in elliptic function.
            const double p_theta_max = 2; // 1; // 0.1; // 1; // 2;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = p_theta_max.ToString(provider);

            this.Calculate(p_theta_max);

            Controls.Add(PlotView1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = textBox1.Text;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double p_theta_max))
            {
                this.Calculate(p_theta_max);
            }
        }

        private void Calculate(double p_theta_max)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            double interval = 25.0 * 2.0 * Math.PI; // 25 oscillations    

            ulong number_of_steps = 1000;
            Console.WriteLine("Pendulum (slinger)      RKCV8");

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsPendulum5Aug2024<double>(), Method.RKCV8);
            // angle: theta, canonical momentum: p_theta

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                           0.0,
                                           p_theta_max);

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: 1000, interval: interval, x_end: interval);

            PlotModel plotModel = new PlotModel();
            LineSeries series = new LineSeries();

            for (int i = 0; i < solutions.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions[i];
                series.Points.Add(new DataPoint(solution.X, solution.Y[0]));
            }

            plotModel.Series.Add(series);

            this.PlotView1.Model = plotModel;
        }

    }
}
