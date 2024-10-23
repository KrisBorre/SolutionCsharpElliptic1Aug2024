namespace WinFormsDifferentialEquationsButcherExercise20point2_3Sep2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations.";

            int width = 1050;
            int height = 550;
            this.ClientSize = new Size(width, height);

            ControlManager controlManager = new ControlManager(width: width, height: height);

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
