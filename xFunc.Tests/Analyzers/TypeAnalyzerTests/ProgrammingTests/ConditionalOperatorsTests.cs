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
using xFunc.Maths.Analyzers.TypeAnalyzers;
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.ComplexNumbers;
using xFunc.Maths.Expressions.LogicalAndBitwise;
using xFunc.Maths.Expressions.Programming;
using Xunit;

namespace xFunc.Tests.Analyzers.TypeAnalyzerTests.ProgrammingTests
{
    public class ConditionalOperatorsTests : TypeAnalyzerBaseTests
    {
        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestUndefined(Type type)
        {
            var exp = CreateBinary(type, Variable.X, Variable.X);

            Test(exp, ResultTypes.Boolean);
        }

        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestBoolUndefined(Type type)
        {
            var exp = CreateBinary(type, Bool.True, Variable.X);

            Test(exp, ResultTypes.Boolean);
        }

        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestUndefinedBool(Type type)
        {
            var exp = CreateBinary(type, Variable.X, Bool.True);

            Test(exp, ResultTypes.Boolean);
        }

        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestBool(Type type)
        {
            var exp = CreateBinary(type, Bool.False, Bool.True);

            Test(exp, ResultTypes.Boolean);
        }

        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestComplexBool(Type type)
        {
            var exp = CreateBinary(type, new ComplexNumber(2, 3), Bool.False);

            TestBinaryException(exp);
        }

        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestBoolComplex(Type type)
        {
            var exp = CreateBinary(type, Bool.False, new ComplexNumber(2, 3));

            TestBinaryException(exp);
        }

        [Theory]
        [InlineData(typeof(ConditionalAnd))]
        [InlineData(typeof(ConditionalOr))]
        public void TestConditionalException(Type type)
        {
            var exp = CreateBinary(type, new ComplexNumber(2, 3), new ComplexNumber(2, 3));

            TestException(exp);
        }
    }
}