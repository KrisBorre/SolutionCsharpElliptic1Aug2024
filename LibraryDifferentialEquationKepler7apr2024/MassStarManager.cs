using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationKepler7apr2024
{
    public class MassStarManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public MassStarManager(ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant) : base(mass_star_configuration)
        { }

        public T GetMassStar(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
