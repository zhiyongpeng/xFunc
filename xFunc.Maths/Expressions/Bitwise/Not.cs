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

namespace xFunc.Maths.Expressions.Bitwise
{

    /// <summary>
    /// Represents a bitwise NOT operation.
    /// </summary>
    public class Not : UnaryMathExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Not"/> class.
        /// </summary>
        internal Not() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Not"/> class.
        /// </summary>
        /// <param name="firstMathExpression">The argument of function.</param>
        /// <seealso cref="IExpression"/>
        public Not(IExpression firstMathExpression)
            : base(firstMathExpression)
        {

        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode(3023);
        }

        /// <summary>
        /// Converts this expression to the equivalent string.
        /// </summary>
        /// <returns>The string that represents this expression.</returns>
        public override string ToString()
        {
            return ToString("not({0})");
        }

        /// <summary>
        /// Calculates this bitwise NOT expression. Don't use this method if your expression has variables.
        /// </summary>
        /// <returns>A result of the calculation.</returns>
        public override double Calculate()
        {
#if PORTABLE
            return ~(int)Math.Round(argument.Calculate());
#else
            return ~(int)Math.Round(argument.Calculate(), MidpointRounding.AwayFromZero);
#endif
        }

        /// <summary>
        /// Calculates this bitwise NOT expression.
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        public override double Calculate(ExpressionParameters parameters)
        {
#if PORTABLE
            return ~(int)Math.Round(argument.Calculate(parameters));
#else
            return ~(int)Math.Round(argument.Calculate(parameters), MidpointRounding.AwayFromZero);
#endif
        }

        /// <summary>
        /// Clones this instance of the <see cref="Not"/>.
        /// </summary>
        /// <returns>Returns the new instance of <see cref="IExpression"/> that is a clone of this instance.</returns>
        public override IExpression Clone()
        {
            return new Not(argument.Clone());
        }

        /// <summary>
        /// Always throws <see cref="NotSupportedException" />.
        /// </summary>
        /// <param name="variable">The variable of differentiation.</param>
        /// <returns>
        /// Throws an exception.
        /// </returns>
        /// <seealso cref="Variable" />
        /// <exception cref="System.NotSupportedException">Always.</exception>
        protected override IExpression _Differentiation(Variable variable)
        {
            throw new NotSupportedException();
        }

    }

}
