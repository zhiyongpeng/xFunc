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
using xFunc.Maths.Expressions.Statistical;
using Xunit;

namespace xFunc.Tests.Expressions.Statistical
{
    public class VarTest
    {
        [Fact]
        public void OneNumberTest()
        {
            var exp = new Var(new[] { new Number(4) });
            var result = (NumberValue)exp.Execute();

            Assert.True(result.IsNaN);
        }

        [Fact]
        public void TwoNumberTest()
        {
            var exp = new Var(new[] { new Number(4), new Number(9) });
            var result = exp.Execute();
            var expected = new NumberValue(12.5);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThreeNumberTest()
        {
            var exp = new Var(new[] { new Number(9), Number.Two, new Number(4) });
            var result = exp.Execute();
            var expected = new NumberValue(13.0);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void VectorTest()
        {
            var exp = new Var(new[] { new Vector(new[] { Number.Two, new Number(4), new Number(9) }) });
            var result = exp.Execute();
            var expected = new NumberValue(13.0);

            Assert.Equal(expected, result);
        }
    }
}