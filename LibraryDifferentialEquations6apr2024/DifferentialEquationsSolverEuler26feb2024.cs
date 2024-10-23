using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public class DifferentialEquationsSolverEuler26feb2024<T> : DifferentialEquationsSolverBaseClass26feb2024<T>
        where T : INumber<T>
    {
        T b1 = T.One;

        public DifferentialEquationsSolverEuler26feb2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations) : base(differentialEquations)
        { }

        protected override void runge_kutta_step(T interval, T delta_x, T x, T[] y, out T[] term)
        {
            term = new T[numberOfFirstOrderEquations];

            T[] k1 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                k1[i] = differentialEquations[i].function(interval, x, y) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i];
            }
        }

    }
}


