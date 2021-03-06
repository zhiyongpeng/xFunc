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

using xFunc.Maths.Expressions.Collections;
using Xunit;

namespace xFunc.Tests.Expressions.Collections
{
    public class ParameterValueTest
    {
        [Fact]
        public void EqualNullTest()
        {
            var value = new ParameterValue(1);

            Assert.False(value.Equals(null as object));
        }

        [Fact]
        public void EqualObjectTest()
        {
            var x = new ParameterValue(1);
            var y = new ParameterValue(1) as object;

            Assert.True(x.Equals(y));
        }

        [Fact]
        public void EqualOperatorTest()
        {
            var x = new ParameterValue(1);
            var y = new ParameterValue(1);

            Assert.True(x == y);
        }

        [Fact]
        public void NotEqualOperatorTest()
        {
            var x = new ParameterValue(1);
            var y = new ParameterValue(2);

            Assert.True(x != y);
        }
    }
}