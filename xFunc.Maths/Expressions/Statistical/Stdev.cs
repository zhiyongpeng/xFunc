// Copyright 2012-2020 Dmytro Kyshchenko
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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using xFunc.Maths.Analyzers;

namespace xFunc.Maths.Expressions.Statistical
{
    /// <summary>
    /// Represents the STDEV function.
    /// </summary>
    /// <seealso cref="DifferentParametersExpression" />
    public class Stdev : StatisticalExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stdev"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public Stdev(IEnumerable<IExpression> arguments)
            : base(arguments)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stdev"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public Stdev(ImmutableArray<IExpression> arguments)
            : base(arguments)
        {
        }

        /// <inheritdoc />
        private protected override double ExecuteInternal(double[] numbers)
        {
            var avg = numbers.Average();
            var sum = 0.0;
            foreach (var number in numbers)
                sum += Math.Pow(number - avg, 2);

            var variance = sum / (numbers.Length - 1);

            return Math.Sqrt(variance);
        }

        /// <inheritdoc />
        private protected override TResult AnalyzeInternal<TResult>(IAnalyzer<TResult> analyzer)
            => analyzer.Analyze(this);

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        private protected override TResult AnalyzeInternal<TResult, TContext>(
            IAnalyzer<TResult, TContext> analyzer,
            TContext context)
            => analyzer.Analyze(this, context);

        /// <inheritdoc />
        public override IExpression Clone(ImmutableArray<IExpression>? arguments = null)
            => new Stdev(arguments ?? Arguments);
    }
}