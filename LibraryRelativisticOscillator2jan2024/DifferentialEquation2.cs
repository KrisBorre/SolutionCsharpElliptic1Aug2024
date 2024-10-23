using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryRelativisticOscillator2jan2024
{
    // The derivative of the velocity (in units of c) is the second equation.
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

        // dv/dt =   .... displacement ...
        public override T function(T interval, T x, params T[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            T k = spring_manager.GetSpring(interval, x);
            T m = mass_manager.GetMass(interval, x);

            return -(k / m) * y[0] * T.CreateChecked(Math.Pow(double.CreateChecked(T.One - y[1] * y[1]), 1.5));
        }
    }
}
