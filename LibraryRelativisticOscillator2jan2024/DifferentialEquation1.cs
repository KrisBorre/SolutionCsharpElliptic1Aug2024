using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryRelativisticOscillator2jan2024
{
    // The derivative of the displacement is the first equation.
    // More specifically, the derivative of the displacement is the velocity.
    internal class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private SpringManager<T> spring_manager;
        private MassManager<T> mass_manager;

        public DifferentialEquation1(SpringManager<T> spring, MassManager<T> mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        // d(displacement) / dt    =   velocity
        public override T function(T interval, T x, params T[] y)
        {
            return y[1];
        }
    }
}
