using LibraryDifferentialEquations6apr2024;
using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationKepler7apr2024
{
    public class DifferentialEquation4<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private MassExoplanetManager<T> mass_exoplanet_manager;
        private MassStarManager<T> mass_star_manager;

        public DifferentialEquation4(MassExoplanetManager<T> mass_exoplanet_manager, MassStarManager<T> mass_star_manager, ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = mass_exoplanet_manager;
            this.mass_star_manager = mass_star_manager;
        }

        public override T function(T interval, T x, params T[] y)
        {
            T mass = mass_exoplanet_manager.GetMassExoplanet(interval, x);
            T Mass = mass_star_manager.GetMassStar(interval, x);

            double temp1 = double.CreateChecked(y[0] * y[0] + y[1] * y[1]);
            return -(y[1] * mass * Mass) / T.CreateChecked(Math.Pow(temp1, 1.5));
        }
    }
}
