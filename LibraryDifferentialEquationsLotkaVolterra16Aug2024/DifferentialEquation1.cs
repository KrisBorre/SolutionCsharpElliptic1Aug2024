using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsLotkaVolterra16Aug2024
{
    internal class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private GammaManager<T> gamma_manager;
        private DeltaManager<T> delta_manager;

        private BetaManager<T> beta_manager;
        private AlphaManager<T> alpha_manager;

        public DifferentialEquation1(BetaManager<T> beta_manager, AlphaManager<T> alpha_manager, GammaManager<T> gamma_manager, DeltaManager<T> delta_manager)
        {
            this.beta_manager = beta_manager;
            this.alpha_manager = alpha_manager;

            this.gamma_manager = gamma_manager;
            this.delta_manager = delta_manager;
        }

        public override T function(T interval, T x, params T[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            T alpha = alpha_manager.GetAlpha(interval, x);
            T beta = beta_manager.GetBeta(interval, x);

            T gamma = gamma_manager.GetGamma(interval, x);
            T delta = delta_manager.GetDelta(interval, x);

            // Butcher (2008) page 22
            // Lotka Volterra problem
            // u' = u(2-v) = 2 u - u v
            // alpha = 2
            // beta = 1
            return (alpha * y[0] - beta * y[0] * y[1]);
        }
    }
}
