using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsDn9apr2024
{
    public class DifferentialEquationsDn9apr2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        public DifferentialEquationsDn9apr2024()
        {
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>();
        }
    }
}
