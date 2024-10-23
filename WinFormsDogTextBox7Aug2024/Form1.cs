namespace WinFormsDogTextBox7Aug2024
{
    public partial class Form1 : Form
    {
        private ControlManager controlManager;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: master-and-dog problem.";

            int width = 816; // 1456; // 816;
            int height = 489; // 557; // 489;
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

            if (this.controlManager.PlotViews != null)
            {
                for (int i = 0; i < this.controlManager.PlotViews.Count; i++)
                {
                    if (this.controlManager.PlotViews[i] != null)
                    {
                        this.controlManager.PlotViews[i].Size = new Size(width, (totalPlotViewheight - 40) / this.controlManager.PlotViews.Count);
                        this.controlManager.PlotViews[i].Location = new Point(0, 40 + i * ((totalPlotViewheight - 40) / this.controlManager.PlotViews.Count));
                    }
                }
            }
        }
    }
}
