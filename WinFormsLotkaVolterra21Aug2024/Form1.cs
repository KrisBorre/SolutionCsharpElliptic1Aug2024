namespace WinFormsLotkaVolterra21Aug2024
{
    public partial class Form1 : Form
    {
        private ControlManager controlManager;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Differential Equations Lotka Volterra";

            int width = 1456;
            int height = 557;

            this.ClientSize = new Size(width, height); // Notice we set the ClientSize, not the Size of the Form.

            this.controlManager = new ControlManager(width: width, height: height);

            foreach (Control control in this.controlManager.Controls)
            {
                this.Controls.Add(control);
            }

            SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            int totalPlotViewheight = height - 40;

            if (this.controlManager.PlotView1 != null)
            {
                this.controlManager.PlotView1.Size = new Size(width, (totalPlotViewheight - 40) / 2);
                this.controlManager.PlotView1.Location = new Point(0, 40);
            }

            if (this.controlManager.PlotView2 != null)
            {
                this.controlManager.PlotView2.Size = new Size(width, (totalPlotViewheight - 40) / 2);
                this.controlManager.PlotView2.Location = new Point(0, 40 + ((totalPlotViewheight - 40) / 2));
            }
        }
    }
}
