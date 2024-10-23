using LibraryDifferentialEquationKepler7apr2024;
using LibraryDifferentialEquations6apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerEllipticOrbit12Aug2024
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

            // https://en.wikipedia.org/wiki/Elliptic_orbit
            Console.WriteLine("Kepler's planetary motion.");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");

            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();

            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(732, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            this.button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.button1.Location = new Point(450, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            this.label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(550, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Eccentricity (between 0 and 1):";

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "Solving a system of differential equations: Kepler's planetary elliptic motion.";

            this.PlotView1 = new PlotView();

            this.PlotView1.Size = new Size(width, height - 40);
            this.PlotView1.Location = new Point(0, 40);

            double eccentricity = 0.7; // 3. / 4.; // 0.5; // 0;            

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = eccentricity.ToString(provider);

            this.Calculate(eccentricity);

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

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double eccentricity))
            {
                this.Calculate(eccentricity);
            }
        }

        private void Calculate(double eccentricity)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            double interval = 2.0 * Math.PI;

            ulong number_of_steps = 200;

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsKepler<double>(), Method.RK61 | Method.Sophisticated);

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                           y1_zero_exact_function(eccentricity),
                                           y2_zero_exact_function(eccentricity),
                                           y3_zero_exact_function(eccentricity),
                                           y4_zero_exact_function(eccentricity));

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)number_of_steps, interval: interval, x_end: interval);

            PlotModel plotModel1 = new PlotModel();
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -2, Maximum = 2 });
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -2, Maximum = 2 });

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle };

            for (int i = 0; i < solutions.Length; i++)
            {
                NumericalSolution8apr2024<double> solution = solutions[i];
                series1.Points.Add(new DataPoint(solution.Y[0], solution.Y[1]));
            }

            plotModel1.Series.Add(series1);
            plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(0, 0), Text = "Elliptic Orbit" });

            this.PlotView1.Model = plotModel1;
        }

        double y1_zero_exact_function(double eccentricity)
        {
            return 1.0 - eccentricity;
        }

        double y2_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        double y3_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        double y4_zero_exact_function(double eccentricity)
        {
            return Math.Sqrt((1.0 + eccentricity) / (1.0 - eccentricity));
        }
    }
}
