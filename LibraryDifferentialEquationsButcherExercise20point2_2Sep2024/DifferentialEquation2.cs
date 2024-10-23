using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsButcherExercise20point2_2Sep2024
{
    public class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation2()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            return (y[1] * (T.One - (T.CreateChecked(2.0) * y[0] * y[1])));
        }
    }
}
