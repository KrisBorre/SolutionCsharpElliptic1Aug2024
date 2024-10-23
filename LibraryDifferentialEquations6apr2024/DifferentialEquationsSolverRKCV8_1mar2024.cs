using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    // Sophisticated Runge Kutta Order 8. See page 197 Butcher (2008) (second edition)
    // Order 7 needs 11 stages.
    // Cooper Verner 8
    public class DifferentialEquationsSolverRKCV8_1mar2024<T> : DifferentialEquationsSolverBaseClass26feb2024<T>
        where T : INumber<T>
    {
        T c2 = T.CreateChecked(1.0 / 2); 
        T a21 = T.CreateChecked(1.0 / 2);
        T c3 = T.CreateChecked(1.0 / 2); 
        T a31 = T.CreateChecked(1.0 / 4);
        T a32 = T.CreateChecked(1.0 / 4); 

        T c4 = T.CreateChecked((7.0 + Math.Sqrt(21.0)) / 14); 
        T a41 = T.CreateChecked(1.0 / 7); 
        T a42 = T.CreateChecked((-7.0 - 3.0 * Math.Sqrt(21.0)) / 98);
        T a43 = T.CreateChecked((21.0 + 5.0 * Math.Sqrt(21.0)) / 49); 

        T c5 = T.CreateChecked((7.0 + Math.Sqrt(21.0)) / 14); 
        T a51 = T.CreateChecked((11.0 + Math.Sqrt(21.0)) / 84);
        T a52 = T.Zero;
        T a53 = T.CreateChecked((18.0 + 4.0 * Math.Sqrt(21.0)) / 63); 
        T a54 = T.CreateChecked((21.0 - Math.Sqrt(21.0)) / 252); 

        T c6 = T.CreateChecked(1.0 / 2); 
        T a61 = T.CreateChecked((5.0 + Math.Sqrt(21.0)) / 48); 
        T a62 = T.Zero;
        T a63 = T.CreateChecked((9.0 + Math.Sqrt(21.0)) / 36); 
        T a64 = T.CreateChecked((-231.0 + 14.0 * Math.Sqrt(21.0)) / 360);
        T a65 = T.CreateChecked((63.0 - 7.0 * Math.Sqrt(21.0)) / 80); 

        T c7 = T.CreateChecked((7.0 - Math.Sqrt(21.0)) / 14); 

        T a71 = T.CreateChecked((10.0 - Math.Sqrt(21.0)) / 42); 
        T a72 = T.Zero;
        T a73 = T.CreateChecked((-432.0 + 92.0 * Math.Sqrt(21.0)) / 315); 
        T a74 = T.CreateChecked((633.0 - 145.0 * Math.Sqrt(21.0)) / 90); 
        T a75 = T.CreateChecked((-504.0 + 115.0 * Math.Sqrt(21.0)) / 70); 
        T a76 = T.CreateChecked((63.0 - 13.0 * Math.Sqrt(21.0)) / 35); 

        T c8 = T.CreateChecked((7.0 - Math.Sqrt(21.0)) / 14); 

        T a81 = T.CreateChecked(1.0 / 14); 
        T a82 = T.Zero;
        T a83 = T.Zero;
        T a84 = T.Zero;
        T a85 = T.CreateChecked((14.0 - 3.0 * Math.Sqrt(21.0)) / 126); 
        T a86 = T.CreateChecked((13.0 - 3.0 * Math.Sqrt(21.0)) / 63); 
        T a87 = T.CreateChecked(1.0 / 9);

        T c9 = T.CreateChecked(1.0 / 2); 

        T a91 = T.CreateChecked(1.0 / 32); 
        T a92 = T.Zero;
        T a93 = T.Zero;
        T a94 = T.Zero;
        T a95 = T.CreateChecked((91.0 - 21.0 * Math.Sqrt(21.0)) / 576);
        T a96 = T.CreateChecked(11.0 / 72); 
        T a97 = T.CreateChecked((-385.0 - 75.0 * Math.Sqrt(21.0)) / 1152); 
        T a98 = T.CreateChecked((63.0 + 13.0 * Math.Sqrt(21.0)) / 128); 

        T c10 = T.CreateChecked((7.0 + Math.Sqrt(21.0)) / 14); 

        T a101 = T.CreateChecked(1.0 / 14); 
        T a102 = T.Zero;
        T a103 = T.Zero;
        T a104 = T.Zero;
        T a105 = T.CreateChecked(1.0 / 9); 
        T a106 = T.CreateChecked((-733.0 - 147.0 * Math.Sqrt(21.0)) / 2205); 
        T a107 = T.CreateChecked((515.0 + 111.0 * Math.Sqrt(21.0)) / 504); 
        T a108 = T.CreateChecked((-51.0 - 11.0 * Math.Sqrt(21.0)) / 56); 
        T a109 = T.CreateChecked((132.0 + 28.0 * Math.Sqrt(21.0)) / 245); 

        T c11 = T.One;

        T a111 = T.Zero;
        T a112 = T.Zero;
        T a113 = T.Zero;
        T a114 = T.Zero;
        T a115 = T.CreateChecked((-42.0 + 7.0 * Math.Sqrt(21.0)) / 18); 
        T a116 = T.CreateChecked((-18.0 + 28.0 * Math.Sqrt(21.0)) / 45); 
        T a117 = T.CreateChecked((-273.0 - 53.0 * Math.Sqrt(21.0)) / 72); 
        T a118 = T.CreateChecked((301.0 + 53.0 * Math.Sqrt(21.0)) / 72); 
        T a119 = T.CreateChecked((28.0 - 28.0 * Math.Sqrt(21.0)) / 45); 
        T a1110 = T.CreateChecked((49.0 - 7.0 * Math.Sqrt(21.0)) / 18); 

        T b1 = T.CreateChecked(1.0 / 20);
        T b2 = T.Zero;
        T b3 = T.Zero;
        T b4 = T.Zero;
        T b5 = T.Zero;
        T b6 = T.Zero;
        T b7 = T.Zero;
        T b8 = T.CreateChecked(49.0 / 180);
        T b9 = T.CreateChecked(16.0 / 45);
        T b10 = T.CreateChecked(49.0 / 180);
        T b11 = T.CreateChecked(1.0 / 20);

        public DifferentialEquationsSolverRKCV8_1mar2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations) : base(differentialEquations)
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

            T[] k7 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a71 + k2[j] * a72 + k3[j] * a73 + k4[j] * a74 + k5[j] * a75 + k6[j] * a76;
                }
                k7[i] = differentialEquations[i].function(interval, x + c7 * delta_x, argument) * delta_x;
            }

            T[] k8 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a81 + k2[j] * a82 + k3[j] * a83 + k4[j] * a84 + k5[j] * a85 + k6[j] * a86 + k7[j] * a87;
                }
                k8[i] = differentialEquations[i].function(interval, x + c8 * delta_x, argument) * delta_x;
            }

            T[] k9 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a91 + k2[j] * a92 + k3[j] * a93 + k4[j] * a94 + k5[j] * a95 + k6[j] * a96 + k7[j] * a97 + k8[j] * a98;
                }
                k9[i] = differentialEquations[i].function(interval, x + c9 * delta_x, argument) * delta_x;
            }

            T[] k10 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a101 + k2[j] * a102 + k3[j] * a103 + k4[j] * a104 + k5[j] * a105 + k6[j] * a106 + k7[j] * a107 + k8[j] * a108 + k9[j] * a109;
                }
                k10[i] = differentialEquations[i].function(interval, x + c10 * delta_x, argument) * delta_x;
            }

            T[] k11 = new T[numberOfFirstOrderEquations];
            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                T[] argument = new T[numberOfFirstOrderEquations];
                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    argument[j] = y[j] + k1[j] * a111 + k2[j] * a112 + k3[j] * a113 + k4[j] * a114 + k5[j] * a115 + k6[j] * a116 + k7[j] * a117 + k8[j] * a118 + k9[j] * a119 + k10[j] * a1110;
                }
                k11[i] = differentialEquations[i].function(interval, x + c11 * delta_x, argument) * delta_x;
            }

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                term[i] = b1 * k1[i] + b2 * k2[i] + b3 * k3[i] + b4 * k4[i] + b5 * k5[i] + b6 * k6[i] + b7 * k7[i] + b8 * k8[i] + b9 * k9[i] + b10 * k10[i] + b11 * k11[i];
            }

        }

    }
}

