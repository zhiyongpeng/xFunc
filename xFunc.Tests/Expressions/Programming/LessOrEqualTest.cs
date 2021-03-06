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

using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.Angles;
using xFunc.Maths.Expressions.Collections;
using xFunc.Maths.Expressions.LogicalAndBitwise;
using xFunc.Maths.Expressions.Programming;
using Xunit;

namespace xFunc.Tests.Expressions.Programming
{
    public class LessOrEqualTest
    {
        [Fact]
        public void CalculateLessTrueTest1()
        {
            var parameters = new ParameterCollection { new Parameter("x", 0) };
            var lessOrEqual = new LessOrEqual(Variable.X, new Number(10));

            Assert.True((bool) lessOrEqual.Execute(parameters));
        }

        [Fact]
        public void CalculateLessTrueTest2()
        {
            var parameters = new ParameterCollection { new Parameter("x", 10) };
            var lessOrEqual = new LessOrEqual(Variable.X, new Number(10));

            Assert.True((bool) lessOrEqual.Execute(parameters));
        }

        [Fact]
        public void CalculateLessFalseTest()
        {
            var parameters = new ParameterCollection { new Parameter("x", 666) };
            var lessOrEqual = new LessOrEqual(Variable.X, new Number(10));

            Assert.False((bool) lessOrEqual.Execute(parameters));
        }

        [Fact]
        public void LessOrEqualAngleTest()
        {
            var exp = new LessOrEqual(
                AngleValue.Degree(10).AsExpression(),
                AngleValue.Degree(12).AsExpression()
            );
            var result = (bool)exp.Execute();

            Assert.True(result);
        }

        [Fact]
        public void CalculateInvalidTypeTest()
        {
            var lessOrEqual = new LessOrEqual(Bool.True, Bool.True);

            Assert.Throws<ResultIsNotSupportedException>(() => lessOrEqual.Execute());
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new LessOrEqual(Number.Two, new Number(3));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }
    }
}