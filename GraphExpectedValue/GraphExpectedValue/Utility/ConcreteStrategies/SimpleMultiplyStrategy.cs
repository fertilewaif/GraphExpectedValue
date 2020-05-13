﻿using System;
using MathNet.Symbolics;

namespace GraphExpectedValue.Utility.ConcreteStrategies
{
    /// <summary>
    /// "Стратегия" умножения матриц "по определению"
    /// </summary>
    public class SimpleMultiplyStrategy : MultiplyStrategy
    {
        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        public Matrix Multiply(Matrix lhs, Matrix rhs)
        {
            if (lhs.Cols != rhs.Rows)
            {
                throw new ArgumentException("Incorrect matrix sizes");
            }
            var result = new Matrix(lhs.Rows, rhs.Cols);
            for (var i = 0; i < result.Rows; i++)
            {
                for (var j = 0; j < result.Cols; j++)
                {
                    result[i, j] = SymbolicExpression.Zero;
                    for (var k = 0; k < lhs.Cols; k++)
                    {
                        result[i, j] += lhs[i, k] * rhs[k, j];
                    }
                }
            }

            return result;
        }

        public override string ToString() => "Simple multiply";
    }
}