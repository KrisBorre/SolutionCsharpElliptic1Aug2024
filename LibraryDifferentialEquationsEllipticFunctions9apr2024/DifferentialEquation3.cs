using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsEllipticFunctions9apr2024
{
    public class DifferentialEquation3<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation3()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {   
            // derivative of the elliptic function dn is - k^2 sn cn
            return -T.CreateChecked(0.5) * (y[0] * y[1]);
        }
    }
}
