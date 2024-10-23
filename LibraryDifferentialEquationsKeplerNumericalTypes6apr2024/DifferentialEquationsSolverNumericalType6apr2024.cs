using LibraryDifferentialEquationKepler7apr2024;
using LibraryDifferentialEquations6apr2024;
using LibraryInitialValueProblemSolver6apr2024;

namespace LibraryDifferentialEquationsKeplerNumericalTypes6apr2024
{
    public class DifferentialEquationsSolverNumericalType6apr2024
    {
        private NumericalType12mar2024 numericalType;

        private DifferentialEquationsSolver26feb2024<decimal>? differentialEquationsSolverDecimal26feb2024 = null;
        private DifferentialEquationsSolver26feb2024<double>? differentialEquationsSolverDouble26feb2024 = null;
        private DifferentialEquationsSolver26feb2024<float>? differentialEquationsSolverFloat26feb2024 = null;
        private DifferentialEquationsSolver26feb2024<Half>? differentialEquationsSolverHalf26feb2024 = null;

        public DifferentialEquationsSolverNumericalType6apr2024(// "Kepler"
            NumericalType12mar2024 numericalType = NumericalType12mar2024.Double,
            Method method = Method.RK41)
        {
            this.numericalType = numericalType;

            if (numericalType == NumericalType12mar2024.Double)
            {
                DifferentialEquationsBaseClass26feb2024<double> differentialEquations = new DifferentialEquationsKepler<double>();
                differentialEquationsSolverDouble26feb2024 = new DifferentialEquationsSolver26feb2024<double>(differentialEquations, method);
            }
            else if (numericalType == NumericalType12mar2024.Float)
            {
                DifferentialEquationsBaseClass26feb2024<float> differentialEquations = new DifferentialEquationsKepler<float>();
                differentialEquationsSolverFloat26feb2024 = new DifferentialEquationsSolver26feb2024<float>(differentialEquations, method);
            }
            else if (numericalType == NumericalType12mar2024.Half)
            {
                DifferentialEquationsBaseClass26feb2024<Half> differentialEquations = new DifferentialEquationsKepler<Half>();
                differentialEquationsSolverHalf26feb2024 = new DifferentialEquationsSolver26feb2024<Half>(differentialEquations, method);
            }
            else if (numericalType == NumericalType12mar2024.Decimal)
            {
                DifferentialEquationsBaseClass26feb2024<decimal> differentialEquations = new DifferentialEquationsKepler<decimal>();
                differentialEquationsSolverDecimal26feb2024 = new DifferentialEquationsSolver26feb2024<decimal>(differentialEquations, method);
            }
            else throw new NotImplementedException();
        }

        public void Solve(double interval, double x_end, ConditionInitial26feb2024<double> initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolution8apr2024<double> solution)
        {
            if (numericalType == NumericalType12mar2024.Double && differentialEquationsSolverDouble26feb2024 != null)
            {
                differentialEquationsSolverDouble26feb2024.Solve(interval, x_end, initialCondition, number_of_steps, out delta_x, out solution);
            }
            else if (numericalType == NumericalType12mar2024.Float && differentialEquationsSolverFloat26feb2024 != null)
            {
                int length = initialCondition.Y.Length;
                float[] y0 = new float[length];
                for (int i = 0; i < length; i++)
                {
                    y0[i] = (float)initialCondition.Y[i];
                }

                ConditionInitial26feb2024<float> initialConditionFloat = new ConditionInitial26feb2024<float>(0, y0);
                differentialEquationsSolverFloat26feb2024.Solve((float)interval, (float)x_end, initialConditionFloat, number_of_steps, out float delta_x_float, out NumericalSolution8apr2024<float> solutionFloat);
                delta_x = delta_x_float;
                double[] y = new double[length];
                for (int i = 0; i < length; i++)
                {
                    y[i] = solutionFloat.Y[i];
                }
                solution = new NumericalSolution8apr2024<double>(y);
            }
            else if (numericalType == NumericalType12mar2024.Half && differentialEquationsSolverHalf26feb2024 != null)
            {
                int length = initialCondition.Y.Length;
                Half[] y0 = new Half[length];
                for (int i = 0; i < length; i++)
                {
                    y0[i] = (Half)initialCondition.Y[i];
                }

                ConditionInitial26feb2024<Half> initialConditionHalf = new ConditionInitial26feb2024<Half>(Half.Zero, y0);
                differentialEquationsSolverHalf26feb2024.Solve((Half)interval, (Half)x_end, initialConditionHalf, number_of_steps, out Half delta_x_Half, out NumericalSolution8apr2024<Half> solutionHalf);
                delta_x = (double)delta_x_Half;
                double[] y = new double[length];
                for (int i = 0; i < length; i++)
                {
                    y[i] = (double)solutionHalf.Y[i];
                }
                solution = new NumericalSolution8apr2024<double>(y);
            }
            else if (numericalType == NumericalType12mar2024.Decimal && differentialEquationsSolverDecimal26feb2024 != null)
            {
                int length = initialCondition.Y.Length;
                decimal[] y0 = new decimal[length];
                for (int i = 0; i < length; i++)
                {
                    y0[i] = (decimal)initialCondition.Y[i];
                }

                ConditionInitial26feb2024<decimal> initialConditionDecimal = new ConditionInitial26feb2024<decimal>(0, y0);
                differentialEquationsSolverDecimal26feb2024.Solve((decimal)interval, (decimal)x_end, initialConditionDecimal, number_of_steps, out decimal delta_x_decimal, out NumericalSolution8apr2024<decimal> solutionDecimal);
                delta_x = (double)delta_x_decimal;
                double[] y = new double[length];
                for (int i = 0; i < length; i++)
                {
                    y[i] = (double)solutionDecimal.Y[i];
                }
                solution = new NumericalSolution8apr2024<double>(y);
            }
            else
            {
                delta_x = 0.0;
                solution = null;
            }
        }




        public void Solve(double interval, double x_end, ConditionInitial26feb2024<double> initialCondition, ulong number_of_steps, out double delta_x, out NumericalSolutions26feb2024<double> solutions, int number_of_solutions = 10000)
        {
            if (numericalType == NumericalType12mar2024.Double && differentialEquationsSolverDouble26feb2024 != null)
            {
                differentialEquationsSolverDouble26feb2024.Solve(interval, x_end, initialCondition, number_of_steps, out delta_x, out solutions, number_of_solutions);
            }
            else if (numericalType == NumericalType12mar2024.Float && differentialEquationsSolverFloat26feb2024 != null)
            {
                int length = initialCondition.Y.Length; // 4
                float[] y0 = new float[length];
                for (int i = 0; i < length; i++)
                {
                    y0[i] = (float)initialCondition.Y[i];
                }

                ConditionInitial26feb2024<float> initialConditionFloat = new ConditionInitial26feb2024<float>(0, y0);
                differentialEquationsSolverFloat26feb2024.Solve((float)interval, (float)x_end, initialConditionFloat, number_of_steps, out float delta_x_float, out NumericalSolutions26feb2024<float> solutionsFloat, number_of_solutions);
                delta_x = delta_x_float;

                solutions = new NumericalSolutions26feb2024<double>();
                solutions.NumberOfSolutions = solutionsFloat.NumberOfSolutions;
                for (int j = 0; j < solutionsFloat.NumberOfSolutions; j++)
                {
                    double[] y = new double[length];
                    for (int i = 0; i < length; i++)
                    {
                        y[i] = solutionsFloat[j].Y[i];
                    }
                    solutions[j] = new NumericalSolution8apr2024<double>(y);
                    solutions[j].X = solutionsFloat[j].X;
                }
            }
            else if (numericalType == NumericalType12mar2024.Half && differentialEquationsSolverHalf26feb2024 != null)
            {
                int length = initialCondition.Y.Length; // 4
                Half[] y0 = new Half[length];
                for (int i = 0; i < length; i++)
                {
                    y0[i] = (Half)initialCondition.Y[i];
                }

                ConditionInitial26feb2024<Half> initialConditionHalf = new ConditionInitial26feb2024<Half>(Half.Zero, y0);
                differentialEquationsSolverHalf26feb2024.Solve((Half)interval, (Half)x_end, initialConditionHalf, number_of_steps, out Half delta_x_Half, out NumericalSolutions26feb2024<Half> solutionsHalf, number_of_solutions);
                delta_x = (double)delta_x_Half;

                solutions = new NumericalSolutions26feb2024<double>();
                solutions.NumberOfSolutions = solutionsHalf.NumberOfSolutions;
                for (int j = 0; j < solutionsHalf.NumberOfSolutions; j++)
                {
                    double[] y = new double[length];
                    for (int i = 0; i < length; i++)
                    {
                        y[i] = (double)solutionsHalf[j].Y[i];
                    }
                    solutions[j] = new NumericalSolution8apr2024<double>(y);
                    solutions[j].X = (double)solutionsHalf[j].X;
                }
            }
            else if (numericalType == NumericalType12mar2024.Decimal && differentialEquationsSolverDecimal26feb2024 != null)
            {
                int length = initialCondition.Y.Length; // 4
                decimal[] y0 = new decimal[length];
                for (int i = 0; i < length; i++)
                {
                    y0[i] = (decimal)initialCondition.Y[i];
                }

                ConditionInitial26feb2024<decimal> initialConditionDecimal = new ConditionInitial26feb2024<decimal>(0, y0);
                differentialEquationsSolverDecimal26feb2024.Solve((decimal)interval, (decimal)x_end, initialConditionDecimal, number_of_steps, out decimal delta_x_decimal, out NumericalSolutions26feb2024<decimal> solutionsDecimal, number_of_solutions);
                delta_x = (double)delta_x_decimal;

                solutions = new NumericalSolutions26feb2024<double>();
                solutions.NumberOfSolutions = solutionsDecimal.NumberOfSolutions;
                for (int j = 0; j < solutionsDecimal.NumberOfSolutions; j++)
                {
                    double[] y = new double[length];
                    for (int i = 0; i < length; i++)
                    {
                        y[i] = (double)solutionsDecimal[j].Y[i];
                    }
                    solutions[j] = new NumericalSolution8apr2024<double>(y);
                    solutions[j].X = (double)solutionsDecimal[j].X;
                }
            }
            else
            {
                delta_x = 0.0;
                solutions = null;
            }
        }

    }
}
