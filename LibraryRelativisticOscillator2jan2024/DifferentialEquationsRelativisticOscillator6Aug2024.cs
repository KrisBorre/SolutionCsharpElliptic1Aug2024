using LibraryDifferentialEquations6apr2024;
using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryRelativisticOscillator2jan2024
{
    public class DifferentialEquationsRelativisticOscillator6Aug2024<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private MassManager<T> mass_manager;
        private SpringManager<T> spring_manager;

        public DifferentialEquationsRelativisticOscillator6Aug2024(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.spring_manager = new SpringManager<T>(spring_configuration);
            this.mass_manager = new MassManager<T>(mass_configuration);

            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>(spring_manager, mass_manager);
            this[1] = new DifferentialEquation2<T>(spring_manager, mass_manager);
        }

        public T GetSpring(T interval, T t)
        {
            return spring_manager.GetSpring(interval, t);
        }

        public T GetMass(T interval, T t)
        {
            return mass_manager.GetMass(interval, t);
        }
    }
}

