using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorMomentum16feb2024
{
    internal class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private SpringManager<T> spring_manager;
        private MassManager<T> mass_manager;

        public DifferentialEquation2(SpringManager<T> spring, MassManager<T> mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        public override T function(T interval, T x, params T[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            T k = spring_manager.GetSpring(interval, x);

            return -k * y[0];
        }
    }
}
