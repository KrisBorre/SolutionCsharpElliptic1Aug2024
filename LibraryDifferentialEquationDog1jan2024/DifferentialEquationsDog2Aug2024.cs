using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationDog1jan2024
{
    public class DifferentialEquationsDog2Aug2024<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquationsDog2Aug2024(double ratio = 0.5)
        {
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>(T.CreateChecked(ratio));
        }
    }
}