using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsEllipticFunctions9apr2024
{
    public class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation1()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            // derivative of the elliptic function sn is cn dn
            return y[1] * y[2];
        }
    }
}
