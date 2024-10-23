using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public class DifferentialEquationsSolverRK41_26feb2024<T> : DifferentialEquationsSolverBaseClass26feb2024<T>
        where T : INumber<T>
    {
        // See page 87 Butcher (2008)
        // Runge Kutta 41. See page 99 Butcher (2008)
        T c2 = T.CreateChecked(1.0 / 2.0); 
        T a21 = T.CreateChecked(1.0 / 2.0);
        T c3 = T.CreateChecked(1.0 / 2.0);
        T a31 = T.Zero;
        T a32 = T.CreateChecked(1.0 / 2.0);
        T c4 = T.One;
        T a41 = T.Zero;
        T a42 = T.Zero;
        T a43 = T.One;

        T b1 = T.CreateChecked(1.0 / 6.0);
        T b2 = T.CreateChecked(1.0 / 3.0);
        T b3 = T.CreateChecked(1.0 / 3.0);
        T b4 = T.CreateChecked(1.0 / 6.0);

        public DifferentialEquationsSolverRK41_26feb2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations) : base(differentialEquations)
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

            T[] k3 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a31 + k2[j] * a32;
                }
                k3[i] = differentialEquations[i].function(interval, x + c3 * delta_x, argument) * delta_x;
            }

            T[] k4 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a41 + k2[j] * a42 + k3[j] * a43;
                }
                k4[i] = differentialEquations[i].function(interval, x + c4 * delta_x, argument) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i];
            }
        }

    }
}


