using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsLotkaVolterra16Aug2024
{
    public class DeltaManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public DeltaManager(ParameterConfiguration delta_configuration = ParameterConfiguration.Constant) : base(delta_configuration)
        { }

        public T GetDelta(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
