using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryInitialValueProblemSolver6apr2024
{
    public class DifferentialEquationsSolver26feb2024<T> : ISolver26feb2024<T>
        where T : INumber<T>
    {
        private DifferentialEquationsSolverBaseClass26feb2024<T> differentialEquationsSolverBaseClass;
        private bool sophisticated;

        public DifferentialEquationsSolver26feb2024(DifferentialEquationsBaseClass26feb2024<T> differentialEquations, Method method = Method.RK41)
        {
            switch (method)
            {
                case Method.Euler | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler26feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.Euler | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler26feb2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK21 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK21_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK21 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK21_29feb2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK22 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK22_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK22 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK22_29feb2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK31 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK31_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK31 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK31_29feb2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK41 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_26feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK41 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_26feb2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK42 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK42_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK42 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK42_29feb2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK5 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK5_1mar2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK5 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK5_1mar2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RK61 | Method.Sophisticated:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_1mar2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK61 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_1mar2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RKCV8 | Method.Sophisticated:
                    // Sophisticated Runge Kutta Order 8. See page 197 Butcher (2008) (second edition)
                    // Order 7 needs 11 stages.
                    // Cooper Verner 8
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8_1mar2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RKCV8 | Method.Crude:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8_1mar2024<T>(differentialEquations);
                    this.sophisticated = false;
                    break;
                case Method.RKCV8:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRKCV8_1mar2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK61:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK61_1mar2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK5:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK5_1mar2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK42:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK42_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK41:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK41_26feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK31:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK31_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK22:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK22_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.RK21:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverRK21_29feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                case Method.Euler:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler26feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
                default:
                    this.differentialEquationsSolverBaseClass = new DifferentialEquationsSolverEuler26feb2024<T>(differentialEquations);
                    this.sophisticated = true;
                    break;
            }
        }

        public void Solve(T interval, T x_end, ConditionInitial26feb2024<T> initialCondition, ulong number_of_steps, out T delta_x, out NumericalSolution8apr2024<T> solution)
        {
            differentialEquationsSolverBaseClass.Solve(initialCondition, number_of_steps, out delta_x, out solution, interval, this.sophisticated, x_end);
        }

        public void Solve(T interval, T x_end, ConditionInitial26feb2024<T> initialCondition, ulong number_of_steps, out T delta_x, out NumericalSolutions26feb2024<T> solutions, int number_of_solutions = 10000)
        {
            differentialEquationsSolverBaseClass.Solve(initialCondition, number_of_steps, out delta_x, out solutions, number_of_solutions, interval, this.sophisticated, x_end);
        }
    }
}