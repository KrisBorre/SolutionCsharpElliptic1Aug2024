using System.Numerics;

namespace LibraryDifferentialEquations6apr2024
{
    public abstract class DifferentialEquationsSolverBaseClass26feb2024<T>
        where T : INumber<T>
    {
        protected DifferentialEquationsBaseClass26feb2024<T> differentialEquations;
        protected int numberOfFirstOrderEquations;

        public DifferentialEquationsSolverBaseClass26feb2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations)
        {
            if (differentialEquations == null)
            {
                throw new Exception("Sorry, Runge Kutta is verkeerd aangeroepen. Hierop kan ik geen Runge Kutta methode uitvoeren.");
            }
            else
            {
                this.differentialEquations = differentialEquations;
                this.numberOfFirstOrderEquations = differentialEquations.NumberOfFirstOrderEquations;
            }
        }

        abstract protected void runge_kutta_step(T interval, T delta_x, T x, T[] y, out T[] term);

        public void Solve(ConditionInitial26feb2024<T> initialCondition, ulong number_of_steps, out T delta_x, out NumericalSolution8apr2024<T> solution, T interval, bool sophisticated, T x_end)
        {
            delta_x = interval / T.CreateChecked(number_of_steps);

            T[] y = new T[numberOfFirstOrderEquations];

            T x = initialCondition.X;

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                y[i] = initialCondition.Y[i];
            }

            T[] z = new T[numberOfFirstOrderEquations];
            T[] new_y = new T[numberOfFirstOrderEquations];
            T[] term;

            for (ulong k = 1; k <= number_of_steps; k++)
            {
                runge_kutta_step(interval, delta_x, x, y, out term);

                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    if (sophisticated)
                    {
                        term[j] += z[j];
                        new_y[j] = y[j] + term[j];
                        z[j] = term[j] - (new_y[j] - y[j]);
                        y[j] = new_y[j];
                    }
                    else
                    {
                        y[j] += term[j];
                    }
                }

                if (initialCondition.X > x_end)
                {
                    x = initialCondition.X - T.CreateChecked(k) * (delta_x);
                }
                else
                {
                    x = initialCondition.X + T.CreateChecked(k) * delta_x;
                }
            }

            solution = new NumericalSolution8apr2024<T>(y);
            solution.X = x;
        }

        /// <summary>
        /// Solve the entire trajectory.
        /// </summary>
        /// <param name="initialCondition"></param>
        /// <param name="number_of_steps"></param>
        /// <param name="delta_x"></param>
        /// <param name="solutions"></param>
        /// <param name="number_of_solutions"></param>
        /// <param name="interval"></param>
        /// <param name="sophisticated"></param>
        /// <param name="x_end"></param>
        public void Solve(ConditionInitial26feb2024<T> initialCondition, ulong number_of_steps, out T delta_x, out NumericalSolutions26feb2024<T> solutions, int number_of_solutions, T interval, bool sophisticated, T x_end)
        {
            delta_x = interval / T.CreateChecked(number_of_steps);
            int index_solution = 0;

            solutions = new NumericalSolutions26feb2024<T>();
            number_of_solutions = (int)Math.Min(number_of_steps, (ulong)number_of_solutions);
            solutions.NumberOfSolutions = number_of_solutions;

            T[] y = new T[numberOfFirstOrderEquations];

            T x = initialCondition.X;

            for (int i = 0; i < numberOfFirstOrderEquations; i++)
            {
                y[i] = initialCondition.Y[i];
            }

            T[] z = new T[numberOfFirstOrderEquations];
            T[] new_y = new T[numberOfFirstOrderEquations];
            T[] term;

            for (ulong k = 1; k <= number_of_steps; k++)
            {
                runge_kutta_step(interval, delta_x, x, y, out term);

                for (int j = 0; j < numberOfFirstOrderEquations; j++)
                {
                    if (sophisticated)
                    {
                        term[j] += z[j];
                        new_y[j] = y[j] + term[j];
                        z[j] = term[j] - (new_y[j] - y[j]);
                        y[j] = new_y[j];
                    }
                    else
                    {
                        y[j] += term[j];
                    }
                }

                if (initialCondition.X > x_end)
                {
                    x = initialCondition.X - T.CreateChecked(k) * delta_x;
                }
                else
                {
                    x = initialCondition.X + T.CreateChecked(k) * delta_x;
                }

                ulong factor = number_of_steps / (ulong)number_of_solutions;
                ulong some_number = k % factor;
                if (some_number == 0)
                {
                    NumericalSolution8apr2024<T> solution = new NumericalSolution8apr2024<T>(y);
                    solution.X = x;
                    solutions[index_solution] = solution;
                    index_solution++;
                }
            }
        }

    }
}

