using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsCosSin26Aug2024
{
    public class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation2()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            // derivative of the sin is cos
            // derivative of y[1] is y[0]
            return y[0];
        }
    }
}
