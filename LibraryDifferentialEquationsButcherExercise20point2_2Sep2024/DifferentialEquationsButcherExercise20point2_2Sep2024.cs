using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsButcherExercise20point2_2Sep2024
{
    /// <summary>
    /// Butcher (2008) page 65 Exercise 20.2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DifferentialEquationsButcherExercise20point2_2Sep2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        /// <summary>
        /// Butcher (2008) page 65 Exercise 20.2
        /// </summary>
        public DifferentialEquationsButcherExercise20point2_2Sep2024()
        {
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>();            
        }
    }
}
