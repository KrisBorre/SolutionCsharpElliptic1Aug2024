using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public class ConditionInitial26feb2024<T> : ConditionBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private int numberOfFirstOrderEquations;

        private T[] y;

        public T[] Y
        {
            get { return y; }
        }

        public ConditionInitial26feb2024(T x, params T[] y) : base(x)
        {
            if (y != null)
            {
                this.numberOfFirstOrderEquations = y.Length;
                this.y = new T[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    this.y[i] = y[i];
                }
            }
        }
    }
}
