using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationDog1jan2024
{
    public class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public T ratio; // ratio zou ook een functie van x kunnen zijn.

        public DifferentialEquation2(T ratio) // =  0.5)
        {
            this.ratio = ratio; // 1.0 / 2; // v / w
                                // Dog is twice as fast as the master.
        }

        public override T function(T interval, T x, params T[] y)
        {
            return (ratio / x) * T.CreateChecked(Math.Pow(double.CreateChecked(T.One + y[1] * y[1]), 0.5));
        }
    }
}
