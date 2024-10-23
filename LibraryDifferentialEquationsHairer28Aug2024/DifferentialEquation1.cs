using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsHairer28Aug2024
{
    public class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation1()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            return -T.CreateChecked(100.0) * y[0] + y[1];
        }
    }
}
