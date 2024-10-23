using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsButcher29Aug2024
{
    public class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation2()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            return y[0];
        }
    }
}
