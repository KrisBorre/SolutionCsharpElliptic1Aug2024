using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorMomentum16feb2024
{
    public class SpringManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public SpringManager(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant) : base(spring_configuration)
        { }

        public T GetSpring(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}