using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsCn9apr2024
{
    public class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation2()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            double k = 0.5;
            T y3 = T.CreateChecked(Math.Pow(double.CreateChecked(y[0]), 3));
            double k2 = Math.Pow(k, 2);
            T a = T.CreateChecked(-(1 - 2 * k2));
            T b = T.CreateChecked(-2 * k2);
            return a * y[0] + b * y3;
        }
    }
}
