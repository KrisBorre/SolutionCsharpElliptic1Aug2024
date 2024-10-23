using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public class NumericalSolution8apr2024<T>
        where T : INumber<T>
    {
        private int numberOfFirstOrderEquations;
        private T x = T.Zero;
        private T[] y;

        /// <summary>
        /// Dutch: x of de tijd t ;
        /// English: x or the time t ;
        /// </summary>
        public T X
        {
            get { return x; }
            set { x = value; }
        }

        public T[] Y
        {
            get { return y; }
            set { y = value; }
        }

        public NumericalSolution8apr2024(params T[] y)
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
