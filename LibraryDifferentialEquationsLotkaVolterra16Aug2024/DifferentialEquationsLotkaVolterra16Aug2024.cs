using LibraryDifferentialEquations6apr2024;
using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsLotkaVolterra16Aug2024
{
    /// <summary>
    /// Butcher (2008) page 22 Lotka Volterra problem
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DifferentialEquationsLotkaVolterra16Aug2024<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private GammaManager<T> gamma_manager;
        private DeltaManager<T> delta_manager;

        private BetaManager<T> beta_manager;
        private AlphaManager<T> alpha_manager;

        /// <summary>
        /// Butcher (2008) page 22 Lotka Volterra problem
        /// </summary>
        /// <param name="spring_configuration"></param>
        /// <param name="mass_configuration"></param>
        public DifferentialEquationsLotkaVolterra16Aug2024(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.beta_manager = new BetaManager<T>(spring_configuration);
            this.alpha_manager = new AlphaManager<T>(mass_configuration);

            this.gamma_manager = new GammaManager<T>(spring_configuration);
            this.delta_manager = new DeltaManager<T>(mass_configuration);

            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>(beta_manager: beta_manager, alpha_manager: alpha_manager, gamma_manager: gamma_manager, delta_manager: delta_manager);
            this[1] = new DifferentialEquation2<T>(beta_manager: beta_manager, alpha_manager: alpha_manager, gamma_manager: gamma_manager, delta_manager: delta_manager);
        }

        public T GetBeta(T interval, T t)
        {
            return beta_manager.GetBeta(interval, t);
        }

        public T GetAlpha(T interval, T t)
        {
            return alpha_manager.GetAlpha(interval, t);
        }

        public T GetDelta(T interval, T t)
        {
            return delta_manager.GetDelta(interval, t);
        }

        public T GetGamma(T interval, T t)
        {
            return gamma_manager.GetGamma(interval, t);
        }
    }
}

