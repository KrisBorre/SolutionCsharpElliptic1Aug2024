using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsLotkaVolterra16Aug2024
{
    public class BetaManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public BetaManager(ParameterConfiguration beta_configuration = ParameterConfiguration.Constant) : base(beta_configuration)
        { }

        public T GetBeta(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}