using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsEllipticFunctions9apr2024
{
    public class DifferentialEquationsEllipticFunctions9apr2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        public DifferentialEquationsEllipticFunctions9apr2024()
        {
            this.NumberOfFirstOrderEquations = 3;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>();
            this[2] = new DifferentialEquation3<T>();
        }
    }
}
