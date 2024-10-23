using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationDog1jan2024
{
    public class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public override T function(T interval, T x, params T[] y)
        {
            return y[1];
        }
    }
}
