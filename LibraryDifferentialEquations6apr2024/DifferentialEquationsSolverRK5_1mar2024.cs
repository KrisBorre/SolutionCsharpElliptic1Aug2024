using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public class DifferentialEquationsSolverRK5_1mar2024<T> : DifferentialEquationsSolverBaseClass26feb2024<T>
        where T : INumber<T>
    {
        // Runge Kutta 5. See page 99 Butcher (2008)

        T c2 = T.CreateChecked(1.0 / 4);
        T a21 = T.CreateChecked(1.0 / 4);
        T c3 = T.CreateChecked(1.0 / 4);
        T a31 = T.CreateChecked(1.0 / 8.0);
        T a32 = T.CreateChecked(1.0 / 8);
        T c4 = T.CreateChecked(1.0 / 2);
        T a41 = T.Zero;
        T a42 = T.Zero;
        T a43 = T.CreateChecked(1.0 / 2);
        T c5 = T.CreateChecked(3.0 / 4);
        T a51 = T.CreateChecked(3.0 / 16);
        T a52 = T.CreateChecked(-3.0 / 8);
        T a53 = T.CreateChecked(3.0 / 8);
        T a54 = T.CreateChecked(9.0 / 16);
        T c6 = T.One;
        T a61 = T.CreateChecked(-3.0 / 7);
        T a62 = T.CreateChecked(8.0 / 7);
        T a63 = T.CreateChecked(6.0 / 7);
        T a64 = T.CreateChecked(-12.0 / 7);
        T a65 = T.CreateChecked(8.0 / 7);
        T b1 = T.CreateChecked(7.0 / 90);
        T b2 = T.Zero;
        T b3 = T.CreateChecked(32.0 / 90);
        T b4 = T.CreateChecked(12.0 / 90);
        T b5 = T.CreateChecked(32.0 / 90);
        T b6 = T.CreateChecked(7.0 / 90);

        public DifferentialEquationsSolverRK5_1mar2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations) : base(differentialEquations)
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

            T[] k5 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a51 + k2[j] * a52 + k3[j] * a53 + k4[j] * a54;
                }
                k5[i] = differentialEquations[i].function(interval, x + c5 * delta_x, argument) * delta_x;
            }

            T[] k6 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a61 + k2[j] * a62 + k3[j] * a63 + k4[j] * a64 + k5[j] * a65;
                }
                k6[i] = differentialEquations[i].function(interval, x + c6 * delta_x, argument) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i] + b5 * k5[i] + b6 * k6[i];
            }

        }

    }
}

