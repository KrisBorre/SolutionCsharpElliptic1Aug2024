﻿using LibraryDifferentialEquations6apr2024;
using System.Numerics;

namespace LibraryDifferentialEquationsButcher29Aug2024
{
    public class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public DifferentialEquation1()
        {
        }

        public override T function(T interval, T x, params T[] y)
        {
            return y[1] + T.CreateChecked(Math.Sin(double.CreateChecked(x)));
        }
    }
}
