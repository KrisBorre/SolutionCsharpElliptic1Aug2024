using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    /// <summary>
    /// First order differential equation
    /// </summary>
    public abstract class DifferentialEquationsBaseClass26feb2024<T>        
        where T : INumber<T>
    {
        private DifferentialEquationBaseClass26feb2024<T>[] differentialEquations;

        public int Length
        {
            get { return differentialEquations.Length; }
        }

        public int NumberOfFirstOrderEquations
        {
            get { return differentialEquations.Length; }
            set
            {
                differentialEquations = new DifferentialEquationBaseClass26feb2024<T>[value];
            }
        }

        public DifferentialEquationBaseClass26feb2024<T> this[int index]
        {
            get
            {
                return differentialEquations[index];
            }
            set
            {
                differentialEquations[index] = value;
            }
        }
    }
}
