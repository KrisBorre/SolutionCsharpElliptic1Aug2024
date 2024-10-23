namespace WinFormsEllipticIntegrals24Aug2024
{
    public partial class Form1 : Form
    {
        private ControlManager controlManager;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Elliptic integrals";

            int width = 800;
            int height = 450;
            this.ClientSize = new Size(width, height);

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
            int totalPlotViewheight = this.ClientSize.Height - 40;

            if (this.controlManager.PlotView1 != null)
            {
                this.controlManager.PlotView1.Size = new Size(width, totalPlotViewheight);
                this.controlManager.PlotView1.Location = new Point(0, 40);
            }
        }
    }
}
