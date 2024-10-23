namespace WinFormsKeplerNumericalAccuracy7apr2024
{
    internal class DoubleHelper
    {
        public static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        public static double abs(double x)
        {
            return Math.Abs(x);
        }


        public static double y1_zero_exact_function(double eccentricity)
        {
            return 1.0 - eccentricity;
        }

        public static double y2_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        public static double y3_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        public static double y4_zero_exact_function(double eccentricity)
        {
            return sqrt((1.0 + eccentricity) / (1.0 - eccentricity));
        }


        public static double y1_pi_exact_function(double eccentricity)
        {
            return -1.0 - eccentricity;
        }

        public static double y2_pi_exact_function(double eccentricity)
        {
            return 0.0;
        }

        public static double y3_pi_exact_function(double eccentricity)
        {
            return 0.0;
        }

        public static double y4_pi_exact_function(double eccentricity)
        {
            return -sqrt((1.0 - eccentricity) / (1.0 + eccentricity)); // Notice the minus and plus sign!
        }
    }
}
