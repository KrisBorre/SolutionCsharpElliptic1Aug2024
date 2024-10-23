using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsButcherExercise20point1_30Aug2024
{
    /// <summary>
    /// Butcher (2008) page 65 Exercise 20.1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DifferentialEquationsButcherExercise20point1_30Aug2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        /// <summary>
        /// Butcher (2008) page 65 Exercise 20.1
        /// </summary>
        public DifferentialEquationsButcherExercise20point1_30Aug2024()
        {
            this.NumberOfFirstOrderEquations = 1;
            this[0] = new DifferentialEquation1<T>();
        }
    }
}
