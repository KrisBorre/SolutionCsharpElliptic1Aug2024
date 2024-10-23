using LibraryDifferentialEquationKepler7apr2024;
using LibraryDifferentialEquations6apr2024;
using LibraryParameterManager6apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKepler10Aug2024
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

        private ComboBox comboBoxExoplanet;
        private ComboBox comboBoxStar;
        private Label label3;
        private Label label4;

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            comboBoxExoplanet = new ComboBox();
            comboBoxStar = new ComboBox();
            label3 = new Label();
            label4 = new Label();

            comboBoxExoplanet.FormattingEnabled = true;
            comboBoxExoplanet.Location = new Point(565, 12);
            comboBoxExoplanet.Name = "comboBoxExoplanet";
            comboBoxExoplanet.Size = new Size(113, 23);
            comboBoxExoplanet.TabIndex = 0;

            comboBoxStar.FormattingEnabled = true;
            comboBoxStar.Location = new Point(804, 12);
            comboBoxStar.Name = "comboBoxStar";
            comboBoxStar.Size = new Size(113, 23);
            comboBoxStar.TabIndex = 1;

            label3.AutoSize = true;
            label3.Location = new Point(453, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 2;
            label3.Text = "Mass of exoplanet:";

            label4.AutoSize = true;
            label4.Location = new Point(725, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Mass of star:";

            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxStar);
            Controls.Add(comboBoxExoplanet);

            Console.WriteLine("Kepler's planetary motion.");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");

            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();

            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(1352, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            this.button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.button1.Location = new Point(1013, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            this.label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(1132, 15);
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

            this.label1.Text = "Solving a system of differential equations: Star with exoplanet";
            // https://en.wikipedia.org/wiki/List_of_nearest_exoplanets

            this.comboBoxExoplanet.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxStar.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxExoplanet.SelectedIndex = 0;
            this.comboBoxStar.SelectedIndex = 0;

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

            double eccentricity = 0.7; // 3. / 4.; // 0.5; // 0;     

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = eccentricity.ToString(provider);

            this.Calculate(eccentricity);

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

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double eccentricity)
                && (eccentricity >= 0 && eccentricity <= 1))
            {
                this.Calculate(eccentricity);
            }
            else
            {
                eccentricity = 0.7;
                textBox1.Text = eccentricity.ToString(provider);
                this.Calculate(eccentricity);
            }
        }

        private void Calculate(double eccentricity)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");
            ulong number_of_oscillations = 1000;
            double interval = number_of_oscillations * 5.0 * 2.0 * Math.PI;  // 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = number_of_oscillations * 100000; // 10000; //100000; // 1000
            int number_of_solutions = (int)number_of_oscillations * 100;

            ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant;
            if (comboBoxExoplanet.SelectedIndex == 1)
            {
                mass_exoplanet_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxExoplanet.SelectedIndex == 2)
            {
                mass_exoplanet_configuration = ParameterConfiguration.Increase;
            }

            ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant;
            if (comboBoxStar.SelectedIndex == 1)
            {
                mass_star_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxStar.SelectedIndex == 2)
            {
                mass_star_configuration = ParameterConfiguration.Increase;
            }

            var problem = new DifferentialEquationsKepler<double>(mass_exoplanet_configuration: mass_exoplanet_configuration, mass_star_configuration: mass_star_configuration);

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RK61 | Method.Sophisticated);

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                           y1_zero_exact_function(eccentricity),
                                           y2_zero_exact_function(eccentricity),
                                           y3_zero_exact_function(eccentricity),
                                           y4_zero_exact_function(eccentricity));

            Cursor.Current = Cursors.WaitCursor;

            // Takes 4 minutes !
            solver.Solve(interval: interval, x_end: interval, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: number_of_solutions);

            Cursor.Current = Cursors.Default;

            #region         Mass Exoplanet
            {
                PlotModel plotModel1 = new PlotModel();
                LineSeries series1 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series1.Points.Add(new DataPoint(solution.X, problem.GetMassExoplanet(interval, solution.X)));
                }

                plotModel1.Series.Add(series1);
                plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass Exoplanet" });

                this.plotViews[0].Model = plotModel1;
            }
            #endregion

            #region         Mass Star
            {
                PlotModel plotModel2 = new PlotModel();
                LineSeries series2 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series2.Points.Add(new DataPoint(solution.X, problem.GetMassStar(interval, solution.X)));
                }

                plotModel2.Series.Add(series2);
                plotModel2.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass Star" });

                this.plotViews[1].Model = plotModel2;
            }
            #endregion

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
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 0), Text = "X coordinate" });

                this.plotViews[2].Model = plotModel3;
            }
            #endregion


            #region           Energy
            {
                PlotModel plotModel4 = new PlotModel();
                LineSeries series4 = new LineSeries();

                double[] energies = new double[solutions.Length];

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    double energy = this.energy_function(mass_exoplanet: problem.GetMassExoplanet(interval, solution.X), mass_star: problem.GetMassStar(interval, solution.X), y1: solution.Y[0], y2: solution.Y[1], y3: solution.Y[2], y4: solution.Y[3]);
                    energies[i] = energy;
                    series4.Points.Add(new DataPoint(solution.X, energy));
                }

                double energyMax = energies.Max();
                double energyMin = energies.Min();
                double y = energyMin + (energyMax - energyMin) / 2.0;

                plotModel4.Series.Add(series4);
                plotModel4.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, y), Text = "Energy" });

                this.plotViews[3].Model = plotModel4;
            }
            #endregion
        }


        double energy_function(double mass_exoplanet, double mass_star, double y1, double y2, double y3, double y4)
        {
            return ((y3 * y3 + y4 * y4) / (2.0 * mass_exoplanet)) - ((mass_exoplanet * mass_star) / Math.Sqrt(y1 * y1 + y2 * y2));
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
