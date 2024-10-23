using LibraryDifferentialEquations6apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using LibraryParameterManager6apr2024;
using LibraryRelativisticOscillator2jan2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsRelativisticOscillatorTextBox15Aug2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private List<PlotView> plotViews;

        public List<PlotView> PlotViews
        {
            get { return plotViews; }
        }

        private ComboBox comboBoxSpring;
        private ComboBox comboBoxMass;
        private Label label3;
        private Label label4;

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            comboBoxSpring = new ComboBox();
            comboBoxMass = new ComboBox();
            label3 = new Label();
            label4 = new Label();

            label3.AutoSize = true;
            label3.Location = new Point(453, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 2;
            label3.Text = "Spring:";

            comboBoxSpring.FormattingEnabled = true;
            comboBoxSpring.Location = new Point(565, 12);
            comboBoxSpring.Name = "comboBoxSpring";
            comboBoxSpring.Size = new Size(113, 23);
            comboBoxSpring.TabIndex = 0;

            label4.AutoSize = true;
            label4.Location = new Point(725, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Mass:";

            comboBoxMass.FormattingEnabled = true;
            comboBoxMass.Location = new Point(804, 12);
            comboBoxMass.Name = "comboBoxMass";
            comboBoxMass.Size = new Size(113, 23);
            comboBoxMass.TabIndex = 1;

            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxMass);
            Controls.Add(comboBoxSpring);

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
            this.label2.Text = "Ratio of v over c:";

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "Solving a system of differential equations: Relativistic oscillator.";

            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);

            this.comboBoxSpring.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxMass.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxSpring.SelectedIndex = 0;
            this.comboBoxMass.SelectedIndex = 0;

            this.plotViews = new List<PlotView>();
            int numberOfPlots = 4;
            for (int i = 0; i < numberOfPlots; i++)
            {
                PlotView plotView = new PlotView();
                Controls.Add(plotView);
                plotView.Size = new Size(width, (height - 40) / numberOfPlots);
                plotView.Location = new Point(0, 40 + i * ((height - 40) / numberOfPlots));
                this.plotViews.Add(plotView);
            }

            const double ratio = 0.9;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = ratio.ToString(provider);

            this.Calculate(ratio);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = textBox1.Text;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double ratio)
                && (ratio > 0 && ratio < 1))
            {
                this.Calculate(ratio);
            }
            else
            {
                ratio = 0.9;
                textBox1.Text = ratio.ToString(provider);
                this.Calculate(ratio);
            }
        }

        private void Calculate(double ratio)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");
            ulong number_of_oscillations = 100;
            double interval = number_of_oscillations * 5.0 * 2.0 * Math.PI;  // 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = number_of_oscillations * 1000;

            ParameterConfiguration spring_configuration = ParameterConfiguration.Constant;
            if (comboBoxSpring.SelectedIndex == 1)
            {
                spring_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxSpring.SelectedIndex == 2)
            {
                spring_configuration = ParameterConfiguration.Increase;
            }

            ParameterConfiguration mass_configuration = ParameterConfiguration.Constant;
            if (comboBoxMass.SelectedIndex == 1)
            {
                mass_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxMass.SelectedIndex == 2)
            {
                mass_configuration = ParameterConfiguration.Increase;
            }

            var problem = new DifferentialEquationsRelativisticOscillator6Aug2024<double>(spring_configuration: spring_configuration, mass_configuration: mass_configuration);

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RK61);

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                           0.0,
                                           ratio);

            Cursor.Current = Cursors.WaitCursor;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)(1000 * number_of_oscillations), interval: interval, x_end: interval);

            Cursor.Current = Cursors.Default;

            #region          Spring
            {
                PlotModel plotModel0 = new PlotModel();
                LineSeries series0 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series0.Points.Add(new DataPoint(solution.X, problem.GetSpring(interval, solution.X)));
                }

                plotModel0.Series.Add(series0);
                plotModel0.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Spring" });

                this.plotViews[0].Model = plotModel0;
            }
            #endregion

            #region          Mass
            {
                PlotModel plotModel1 = new PlotModel();
                LineSeries series1 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series1.Points.Add(new DataPoint(solution.X, problem.GetMass(interval, solution.X)));
                }

                plotModel1.Series.Add(series1);
                plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass" });

                this.plotViews[1].Model = plotModel1;
            }
            #endregion

            #region       Displacement
            {
                PlotModel plotModel2 = new PlotModel();
                LineSeries series2 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series2.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                }

                plotModel2.Series.Add(series2);
                plotModel2.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 0), Text = "Displacement" });

                this.plotViews[2].Model = plotModel2;
            }
            #endregion

            #region          Energy
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                double[] energies = new double[solutions.Length];

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    double energy = this.energy_function(k: problem.GetSpring(interval, solution.X), m: problem.GetMass(interval, solution.X), y1: solution.Y[0], y2: solution.Y[1]);
                    energies[i] = energy;
                    series3.Points.Add(new DataPoint(solution.X, energy));
                }

                double energyMax = energies.Max();
                double energyMin = energies.Min();
                double y = energyMin + (energyMax - energyMin) / 2.0;

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, y), Text = "Energy" });

                this.plotViews[3].Model = plotModel3;
            }
            #endregion
        }

        private double energy_function(double k, double m, double y1, double y2)
        {
            //double kinetic_energy = (m * y2 * y2) / 2.0; // non-relativistic
            double gamma = Math.Pow(1 - y2 * y2, -0.5);
            double kinetic_energy = gamma * m;
            double potential_energy = (k * y1 * y1) / 2.0;
            return kinetic_energy + potential_energy;
        }
    }
}
