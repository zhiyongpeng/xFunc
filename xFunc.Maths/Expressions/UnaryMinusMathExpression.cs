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

namespace xFunc.Maths.Expressions
{

    public class UnaryMinusMathExpression : UnaryMathExpression
    {

        public UnaryMinusMathExpression() : base(null) { }

        public UnaryMinusMathExpression(IMathExpression firstMathExpression) : base(firstMathExpression) { }

        public override string ToString()
        {
            if (firstMathExpression is BinaryMathExpression)
                return ToString("-({0})");
            else
                return ToString("-{0}");
        }

        public override double Calculate(MathParameterCollection parameters)
        {
            return -firstMathExpression.Calculate(parameters);
        }

        public override IMathExpression Clone()
        {
            return new UnaryMinusMathExpression(firstMathExpression.Clone());
        }

        protected override IMathExpression _Derivative(VariableMathExpression variable)
        {
            return new UnaryMinusMathExpression(firstMathExpression.Clone().Derivative());
        }

    }

}
