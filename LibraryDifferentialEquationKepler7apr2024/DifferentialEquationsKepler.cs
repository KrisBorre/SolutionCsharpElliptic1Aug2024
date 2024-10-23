using LibraryDifferentialEquations6apr2024;
using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationKepler7apr2024
{
    public class DifferentialEquationsKepler<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private MassExoplanetManager<T> mass_exoplanet_manager;
        private MassStarManager<T> mass_star_manager;

        public DifferentialEquationsKepler(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = new MassExoplanetManager<T>(mass_exoplanet_configuration);
            this.mass_star_manager = new MassStarManager<T>(mass_star_configuration);

            this.NumberOfFirstOrderEquations = 4;
            this[0] = new DifferentialEquation1<T>(mass_exoplanet_manager, mass_star_manager);
            this[1] = new DifferentialEquation2<T>(mass_exoplanet_manager, mass_star_manager);
            this[2] = new DifferentialEquation3<T>(mass_exoplanet_manager, mass_star_manager);
            this[3] = new DifferentialEquation4<T>(mass_exoplanet_manager, mass_star_manager);
        }

        public T GetMassExoplanet(T interval, T t)
        {
            return mass_exoplanet_manager.GetMassExoplanet(interval, t);
        }

        public T GetMassStar(T interval, T t)
        {
            return mass_star_manager.GetMassStar(interval, t);
        }
    }
}