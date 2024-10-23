using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryPendulum16feb2024
{
    internal class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private LengthManager<T> length_manager;
        private GravityManager<T> gravity_manager;
        private MassManager<T> mass_manager;

        public DifferentialEquation2(LengthManager<T> length_manager, GravityManager<T> gravity_manager, MassManager<T> mass_manager)
        {
            this.length_manager = length_manager;
            this.gravity_manager = gravity_manager;
            this.mass_manager = mass_manager;
        }

        public override T function(T interval, T x, params T[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            T l = length_manager.GetLength(interval, x);
            T g = gravity_manager.GetGravity(interval, x);
            T m = mass_manager.GetMass(interval, x);

            return -m * g * l * T.CreateChecked(Math.Sin(double.CreateChecked(y[0])));
        }
    }
}
