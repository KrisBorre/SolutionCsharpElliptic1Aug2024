using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsLotkaVolterra16Aug2024
{
    public class GammaManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public GammaManager(ParameterConfiguration gamma_configuration = ParameterConfiguration.Constant) : base(gamma_configuration)
        { }

        public T GetGamma(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}