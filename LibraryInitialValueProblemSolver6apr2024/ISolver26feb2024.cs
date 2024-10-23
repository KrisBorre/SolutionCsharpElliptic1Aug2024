using System.Numerics;
using LibraryDifferentialEquations6apr2024;

namespace LibraryInitialValueProblemSolver6apr2024
{
    public interface ISolver26feb2024<T>
        where T : INumber<T>
    {
        void Solve(T interval, T x_end, ConditionInitial26feb2024<T> initialCondition, ulong number_of_steps, out T delta_x, out NumericalSolution8apr2024<T> solution);
        void Solve(T interval, T x_end, ConditionInitial26feb2024<T> initialCondition, ulong number_of_steps, out T delta_x, out NumericalSolutions26feb2024<T> solutions, int number_of_solutions);
    }
}