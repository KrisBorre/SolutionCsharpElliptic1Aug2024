using LibraryParameterManager6apr2024;
using System.Numerics;

namespace LibraryPendulum16feb2024
{
    public class LengthManager<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public LengthManager(ParameterConfiguration length_configuration = ParameterConfiguration.Constant) : base(length_configuration)
        { }

        public T GetLength(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
