using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsSn9apr2024
{
    public class DifferentialEquationsSn9apr2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        public DifferentialEquationsSn9apr2024()
        {
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>();
        }
    }
}
