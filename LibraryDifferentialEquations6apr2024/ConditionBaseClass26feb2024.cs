using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public abstract class ConditionBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private T x = T.Zero;

        public T X
        {
            get { return x; }
            set { x = value; }
        }

        public ConditionBaseClass26feb2024(T x)
        {
            this.x = x;
        }
    }
}
