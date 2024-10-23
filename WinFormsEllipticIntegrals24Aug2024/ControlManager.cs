using LibraryEllipticIntegrals20dec2023;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsEllipticIntegrals24Aug2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private ComboBox comboBox1;

        public PlotView PlotView1;

        public ControlManager(int width, int height)
        {
            this.controls = new List<Control>();

            comboBox1 = new ComboBox();
            PlotView1 = new PlotView();

            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(width - 30, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            int totalPlotViewheight = height - 40;

            PlotView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlotView1.Location = new Point(0, 40);
            PlotView1.Name = "plotView1";
            PlotView1.PanCursor = Cursors.Hand;
            PlotView1.Size = new Size(width, totalPlotViewheight);
            PlotView1.TabIndex = 1;
            PlotView1.Text = "plotView1";
            PlotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            PlotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            PlotView1.ZoomVerticalCursor = Cursors.SizeNS;

            Controls.Add(PlotView1);
            Controls.Add(comboBox1);

            comboBox1.Items.AddRange(new string[] {
                "Elliptic integral of the first kind: K(k)",
                "Derivative of K(k)",
                "Elliptic integral of the second kind: E(k)",
                "Derivative of E(k)" });
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineSeries lineSeries = new LineSeries();

            double x_minimum = 0;
            double x_maximum = 0.999;

            const int N = 1000; // aantal punten in grafiek.

            EllipticIntegralCalculator20dec2023 calculator = new EllipticIntegralCalculator20dec2023();
            EllipticIntegralK_20dec2023 ellipticIntegralK_20Dec2023 = new EllipticIntegralK_20dec2023(calculator);
            EllipticIntegralE_20dec2023 ellipticIntegralE_20Dec2023 = new EllipticIntegralE_20dec2023(calculator);

            for (int k = 0; k <= N; k++)
            {
                double x = (x_maximum - x_minimum) * ((double)k / N) + x_minimum;
                double y = 0;

                if (comboBox1.SelectedIndex == 0)
                {
                    y = ellipticIntegralK_20Dec2023.Function(x);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    y = ellipticIntegralK_20Dec2023.Derivative(x);
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    y = ellipticIntegralE_20Dec2023.Function(x);
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    y = ellipticIntegralE_20Dec2023.Derivative(x);
                }

                lineSeries.Points.Add(new DataPoint(x, y));
            }

            PlotModel myPlotModel = new PlotModel();
            myPlotModel.Series.Add(lineSeries);
            this.PlotView1.Model = myPlotModel;
        }
    }
}
