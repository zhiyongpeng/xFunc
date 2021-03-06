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
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.Collections;
using xFunc.Maths.Expressions.LogicalAndBitwise;
using xFunc.Maths.Expressions.Programming;
using Xunit;

namespace xFunc.Tests.Expressions.Programming
{
    public class RightShiftAssignTest
    {
        [Fact]
        public void ExecuteTest()
        {
            var exp = new RightShiftAssign(Variable.X, new Number(9));
            var parameters = new ParameterCollection
            {
                new Parameter("x", 512.0)
            };
            var actual = exp.Execute(parameters);
            var expected = new NumberValue(1.0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExecuteAsExpressionTest()
        {
            var exp = new Add(Number.One, new RightShiftAssign(Variable.X, new Number(9)));
            var parameters = new ParameterCollection
            {
                new Parameter("x", 512.0)
            };
            var actual = exp.Execute(parameters);

            Assert.Equal(new NumberValue(2.0), actual);
            Assert.Equal(new NumberValue(1.0), parameters["x"]);
        }

        [Fact]
        public void ExecuteNullParamsTest()
        {
            var exp = new RightShiftAssign(Variable.X, new Number(9));

            Assert.Throws<ArgumentNullException>(() => exp.Execute());
        }

        [Fact]
        public void ExecuteDoubleLeftTest()
        {
            var exp = new RightShiftAssign(Variable.X, new Number(10));
            var parameters = new ParameterCollection
            {
                new Parameter("x", 512.5)
            };

            Assert.Throws<ArgumentException>(() => exp.Execute(parameters));
        }

        [Fact]
        public void ExecuteDoubleRightTest()
        {
            var exp = new RightShiftAssign(Variable.X, new Number(10.1));
            var parameters = new ParameterCollection
            {
                new Parameter("x", 512.0)
            };

            Assert.Throws<ArgumentException>(() => exp.Execute(parameters));
        }

        [Fact]
        public void ExecuteBoolRightTest()
        {
            var exp = new RightShiftAssign(Variable.X, Bool.True);
            var parameters = new ParameterCollection
            {
                new Parameter("x", 512.0)
            };

            Assert.Throws<ResultIsNotSupportedException>(() => exp.Execute(parameters));
        }

        [Fact]
        public void ExecuteBoolLeftTest()
        {
            var exp = new RightShiftAssign(Variable.X, Bool.True);
            var parameters = new ParameterCollection
            {
                new Parameter("x", false)
            };

            Assert.Throws<ResultIsNotSupportedException>(() => exp.Execute(parameters));
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new RightShiftAssign(Variable.X, new Number(10));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }
    }
}