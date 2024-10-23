using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsHairer28Aug2024
{
    /// <summary>
    /// Solving ODEs (2000) page 55
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DifferentialEquationsHairer28Aug2024<T> : DifferentialEquationsBaseClass26feb2024<T>
       where T : INumber<T>
    {
        /// <summary>
        /// Solving ODEs (2000) non-stiff problems, page 55, Ernst Hairer
        /// </summary>
        public DifferentialEquationsHairer28Aug2024()
        {
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>();
        }
    }
}
