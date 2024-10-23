using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public class DifferentialEquationsSolverRK21_29feb2024<T> : DifferentialEquationsSolverBaseClass26feb2024<T>
         where T : INumber<T>
    {
        // Immproved Euler method
        // See page 87 Butcher (2008)
        T c2 = T.One;
        T a21 = T.One;

        T b1 = T.CreateChecked(1.0 / 2.0);
        T b2 = T.CreateChecked(1.0 / 2.0);

        public DifferentialEquationsSolverRK21_29feb2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations) : base(differentialEquations)
        { }

        protected override void runge_kutta_step(T interval, T delta_x, T x, T[] y, out T[] term)
        {
            term = new T[numberOfFirstOrderEquations];

            T[] k1 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                k1[i] = differentialEquations[i].function(interval, x, y) * delta_x;
            }

            T[] k2 = new T[numberOfFirstOrderEquations];

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a21;
                }
                k2[i] = differentialEquations[i].function(interval, x + c2 * delta_x, argument) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i];
            }
        }

    }
}


