using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsButcher29Aug2024
{
    /// <summary>
    /// Butcher (2008) page 27
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DifferentialEquationsButcher29Aug2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        /// <summary>
        /// Butcher (2008) page 27
        /// </summary>
        public DifferentialEquationsButcher29Aug2024()
        {
            this.NumberOfFirstOrderEquations = 3;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>();
            this[2] = new DifferentialEquation3<T>();
        }
    }
}
