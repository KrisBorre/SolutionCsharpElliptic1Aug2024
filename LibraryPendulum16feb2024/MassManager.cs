using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryPendulum16feb2024
{
    public class MassManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public MassManager(ParameterConfiguration mass_configuration = ParameterConfiguration.Constant) : base(mass_configuration)
        { }

        public T GetMass(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
