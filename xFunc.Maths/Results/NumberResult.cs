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

using System.Globalization;

namespace xFunc.Maths.Results
{
    /// <summary>
    /// Represents the numerical result.
    /// </summary>
    public class NumberResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberResult"/> class.
        /// </summary>
        /// <param name="number">The numerical representation of result.</param>
        public NumberResult(double number) => Result = number;

        /// <inheritdoc />
        public override string ToString() => Result.ToString(CultureInfo.InvariantCulture);

        /// <inheritdoc cref="IResult.Result" />
        public double Result { get; }

        /// <inheritdoc />
        object IResult.Result => Result;
    }
}