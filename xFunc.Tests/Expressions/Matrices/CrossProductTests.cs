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
using xFunc.Maths.Expressions.Matrices;
using Xunit;

namespace xFunc.Tests.Expressions.Matrices
{
    public class CrossProductTests : BaseExpressionTests
    {
        [Fact]
        public void ExecuteTest()
        {
            var exp = new CrossProduct(
                new Vector(new[] { Number.One, Number.Two, new Number(3) }),
                new Vector(new[] { new Number(4), new Number(5), new Number(6) })
            );
            var result = exp.Execute();
            var expected = new Vector(new[] { new Number(-3), new Number(6), new Number(-3) });

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ExecuteTypeExceptionTest()
            => TestNotSupported(new CrossProduct(Number.One, Number.Two));

        [Fact]
        public void ExecuteLeftTypeExceptionTest()
        {
            var exp = new CrossProduct(
                Number.One,
                new Vector(new[] { Number.One, Number.Two, new Number(3) }));

            TestNotSupported(exp);
        }

        [Fact]
        public void ExecuteRightTypeExceptionTest()
        {
            var exp = new CrossProduct(
                new Vector(new[] { Number.One, Number.Two, new Number(3) }),
                Number.Two);

            TestNotSupported(exp);
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new CrossProduct(
                new Vector(new[] { Number.One, new Number(-2), new Number(3) }),
                new Vector(new[] { new Number(4), Number.Zero, new Number(6) })
            );
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }
    }
}