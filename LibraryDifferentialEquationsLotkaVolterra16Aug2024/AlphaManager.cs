using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsLotkaVolterra16Aug2024
{
    public class AlphaManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public AlphaManager(ParameterConfiguration alpha_configuration = ParameterConfiguration.Constant) : base(alpha_configuration)
        { }

        public T GetAlpha(T interval, T t)
        {
            return T.CreateChecked(2.0) * base.GetParameter(interval, t);
        }
    }
}
