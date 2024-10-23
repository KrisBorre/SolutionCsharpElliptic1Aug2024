using LibraryDifferentialEquations6apr2024;
using LibraryInitialValueProblemSolver6apr2024;
using LibraryParameterManager6apr2024;
using LibraryPendulum16feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsPendulum14Aug2024
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

        private int numberOfPlots = 5;

        private ComboBox comboBoxGravity;
        private ComboBox comboBoxLength;
        private ComboBox comboBoxMass;
        private Label label3;
        private Label label4;
        private Label label1;
        private Button button1;
        private Label label5;

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            comboBoxGravity = new ComboBox();
            comboBoxLength = new ComboBox();
            comboBoxMass = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();

            label3.AutoSize = true;
            label3.Location = new Point(150, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 2;
            label3.Text = "Gravity:";

            comboBoxGravity.FormattingEnabled = true;
            comboBoxGravity.Location = new Point(225, 12);
            comboBoxGravity.Name = "comboBoxGravity";
            comboBoxGravity.Size = new Size(113, 23);
            comboBoxGravity.TabIndex = 3;

            label4.AutoSize = true;
            label4.Location = new Point(700, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 6;
            label4.Text = "Length:";

            comboBoxLength.FormattingEnabled = true;
            comboBoxLength.Location = new Point(770, 12);
            comboBoxLength.Name = "comboBoxLength";
            comboBoxLength.Size = new Size(113, 23);
            comboBoxLength.TabIndex = 7;

            label5.AutoSize = true;
            label5.Location = new Point(404, 15);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 4;
            label5.Text = "Mass:";

            comboBoxMass.FormattingEnabled = true;
            comboBoxMass.Location = new Point(454, 12);
            comboBoxMass.Name = "comboBoxMass";
            comboBoxMass.Size = new Size(113, 23);
            comboBoxMass.TabIndex = 5;

            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(comboBoxLength);
            Controls.Add(comboBoxGravity);
            Controls.Add(comboBoxMass);

            this.button1 = new Button();
            this.button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.button1.Location = new Point(1113, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "Pendulum";

            Controls.Add(label1);
            Controls.Add(button1);

            this.comboBoxGravity.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxLength.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxMass.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxGravity.SelectedIndex = 0;
            this.comboBoxLength.SelectedIndex = 0;
            this.comboBoxMass.SelectedIndex = 0;

            this.plotViews = new List<PlotView>();

            for (int i = 0; i < this.numberOfPlots; i++)
            {
                PlotView plotView = new PlotView();
                Controls.Add(plotView);
                plotView.Size = new Size(width, (height - 40) / this.numberOfPlots);
                plotView.Location = new Point(0, 40 + i * ((height - 40) / this.numberOfPlots));
                this.plotViews.Add(plotView);
            }

            this.Calculate();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Calculate();
        }

        private void Calculate()
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");
            ulong number_of_oscillations = 100;
            double interval = number_of_oscillations * 5.0 * 2.0 * Math.PI;  // 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = number_of_oscillations * 1000;

            ParameterConfiguration gravity_configuration = ParameterConfiguration.Constant;
            if (comboBoxGravity.SelectedIndex == 1)
            {
                gravity_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxGravity.SelectedIndex == 2)
            {
                gravity_configuration = ParameterConfiguration.Increase;
            }

            ParameterConfiguration length_configuration = ParameterConfiguration.Constant;
            if (comboBoxLength.SelectedIndex == 1)
            {
                length_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxLength.SelectedIndex == 2)
            {
                length_configuration = ParameterConfiguration.Increase;
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

            var problem = new DifferentialEquationsPendulum5Aug2024<double>(gravity_configuration: gravity_configuration, length_configuration: length_configuration, mass_configuration: mass_configuration);

            ISolver26feb2024<double> solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RKCV8);

            double p_theta_max = 1;

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                               0.0,
                               p_theta_max);

            Cursor.Current = Cursors.WaitCursor;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)(1000 * number_of_oscillations), interval: interval, x_end: interval);

            Cursor.Current = Cursors.Default;

            #region          Length
            {
                PlotModel plotModel0 = new PlotModel();
                LineSeries series0 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series0.Points.Add(new DataPoint(solution.X, problem.GetLength(interval, solution.X)));
                }

                plotModel0.Series.Add(series0);
                plotModel0.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Length" });

                this.plotViews[0].Model = plotModel0;
            }
            #endregion

            #region          Gravity
            {
                PlotModel plotModel1 = new PlotModel();
                LineSeries series1 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series1.Points.Add(new DataPoint(solution.X, problem.GetGravity(interval, solution.X)));
                }

                plotModel1.Series.Add(series1);
                plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Gravity" });

                this.plotViews[1].Model = plotModel1;
            }
            #endregion

            #region          Mass
            {
                PlotModel plotModel2 = new PlotModel();
                LineSeries series2 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series2.Points.Add(new DataPoint(solution.X, problem.GetMass(interval, solution.X)));
                }

                plotModel2.Series.Add(series2);
                plotModel2.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass" });

                this.plotViews[2].Model = plotModel2;
            }
            #endregion

            #region       Angle
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    series3.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                }

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 0), Text = "Angle" });

                this.plotViews[3].Model = plotModel3;
            }
            #endregion

            #region          Energy
            {
                PlotModel plotModel4 = new PlotModel();
                LineSeries series4 = new LineSeries();

                double[] energies = new double[solutions.Length];

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution8apr2024<double> solution = solutions[i];
                    double energy = this.energy_function(l: problem.GetLength(interval, solution.X), g: problem.GetGravity(interval, solution.X), m: problem.GetMass(interval, solution.X), y1: solution.Y[0], y2: solution.Y[1]);
                    energies[i] = energy;
                    series4.Points.Add(new DataPoint(solution.X, energy));
                }

                double energyMax = energies.Max();
                double energyMin = energies.Min();
                double y = energyMin + (energyMax - energyMin) / 2.0;

                plotModel4.Series.Add(series4);
                plotModel4.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, y), Text = "Energy" });

                this.plotViews[4].Model = plotModel4;
            }
            #endregion
        }

        private double energy_function(double g, double l, double m, double y1, double y2)
        {
            double kinetic_energy = (y2 * y2) / (2.0 * m * l * l);
            double potential_energy = -m * g * l * Math.Cos(y1);
            return kinetic_energy + potential_energy;
        }
    }
}
