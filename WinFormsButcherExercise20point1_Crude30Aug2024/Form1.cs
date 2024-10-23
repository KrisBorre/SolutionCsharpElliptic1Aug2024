namespace WinFormsButcherExercise20point1_Crude30Aug2024
{
    public partial class Form1 : Form
    {
        private ControlManager controlManager;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Sophisticated Runge-Kutta versus crude Runge-Kutta.";

            int width = 816; // 1456;
            int height = 489; //  557;
            this.ClientSize = new Size(width, height); // Notice we set the ClientSize, not the Size of the Form.

            this.controlManager = new ControlManager(width: width, height: height);

            foreach (Control control in this.controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
