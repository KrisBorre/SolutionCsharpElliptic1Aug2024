namespace WinFormsKeplerNumericalAccuracy7apr2024
{
    internal class DecimalHelper
    {
        public static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        public static decimal abs(decimal x)
        {
            return Math.Abs(x);
        }


        public static decimal y1_zero_exact_function(decimal eccentricity)
        {
            return 1 - eccentricity;
        }

        public static decimal y2_zero_exact_function(decimal eccentricity)
        {
            return 0;
        }

        public static decimal y3_zero_exact_function(decimal eccentricity)
        {
            return 0;
        }

        public static decimal y4_zero_exact_function(decimal eccentricity)
        {
            return (decimal)sqrt((double)((1 + eccentricity) / (1 - eccentricity)));
        }


        public static decimal y1_pi_exact_function(decimal eccentricity)
        {
            return -1 - eccentricity;
        }

        public static decimal y2_pi_exact_function(decimal eccentricity)
        {
            return 0;
        }

        public static decimal y3_pi_exact_function(decimal eccentricity)
        {
            return 0;
        }

        public static decimal y4_pi_exact_function(decimal eccentricity)
        {
            return -(decimal)sqrt((double)((1 - eccentricity) / (1 + eccentricity))); // Notice the minus and plus sign!
        }
    }
}
