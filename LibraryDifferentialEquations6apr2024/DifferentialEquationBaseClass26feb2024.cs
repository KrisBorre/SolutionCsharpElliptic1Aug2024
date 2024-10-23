using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public abstract class DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public abstract T function(T interval, T x, params T[] y);
    }
}
