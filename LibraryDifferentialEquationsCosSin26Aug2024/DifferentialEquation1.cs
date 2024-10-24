﻿using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsCosSin26Aug2024
{
    public class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation1()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            // derivative of the cos is -sin
            // derivative of y[0] is -y[1]
            return -y[1];
        }
    }
}
