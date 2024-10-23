using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryPendulum16feb2024
{
    public class GravityManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public GravityManager(ParameterConfiguration gravity_configuration = ParameterConfiguration.Constant) : base(gravity_configuration)
        { }

        public T GetGravity(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}


