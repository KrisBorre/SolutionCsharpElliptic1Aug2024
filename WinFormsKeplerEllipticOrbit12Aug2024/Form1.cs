namespace WinFormsKeplerEllipticOrbit12Aug2024
{
    public partial class Form1 : Form
    {
        private ControlManager controlManager;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: Kepler's planetary elliptic motion.";

            int width = 800;
            int height = width + 40;

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

            if (this.controlManager.PlotView1 != null)
            {
                this.controlManager.PlotView1.Size = new Size(width, height - 40);
                this.controlManager.PlotView1.Location = new Point(0, 40);
            }
        }
    }
}
