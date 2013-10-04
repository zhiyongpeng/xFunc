﻿// Copyright 2012-2013 Dmitry Kischenko
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
// express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
using System;

namespace xFunc.Maths.Expressions.Trigonometric
{

    /// <summary>
    /// The base class for trigonomeric functions. This is an <c>abstract</c> class.
    /// </summary>
    public abstract class TrigonometryMathExpression : UnaryMathExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigonometryMathExpression"/> class.
        /// </summary>
        protected TrigonometryMathExpression() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigonometryMathExpression"/> class.
        /// </summary>
        /// <param name="firstMathExpression">The argument of function.</param>
        protected TrigonometryMathExpression(IMathExpression firstMathExpression)
            : base(firstMathExpression)
        {
        }

        /// <summary>
        /// Calculates this mathemarical expression (using degree).
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        protected abstract double CalculateDergee(ExpressionParameters parameters);
        /// <summary>
        /// Calculates this mathemarical expression (using radian).
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        protected abstract double CalculateRadian(ExpressionParameters parameters);
        /// <summary>
        /// Calculates this mathemarical expression (using gradian).
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        protected abstract double CalculateGradian(ExpressionParameters parameters);

        /// <summary>
        /// Calculates this mathemarical expression. Don't use this method if your expression has variables or functions.
        /// </summary>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        public override double Calculate()
        {
            return CalculateDergee(null);
        }

        /// <summary>
        /// Calculates this mathemarical expression.
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        public override double Calculate(ExpressionParameters parameters)
        {
            if (parameters.Angleeasurement == AngleMeasurement.Degree)
                return CalculateDergee(parameters);
            if (parameters.Angleeasurement == AngleMeasurement.Radian)
                return CalculateRadian(parameters);
            if (parameters.Angleeasurement == AngleMeasurement.Gradian)
                return CalculateGradian(parameters);

            return double.NaN;
        }

    }

}
