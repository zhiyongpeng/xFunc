﻿// Copyright 2012-2015 Dmitry Kischenko
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
using xFunc.Maths.Expressions.Hyperbolic;
using xFunc.Maths.Expressions.Trigonometric;

namespace xFunc.Maths
{

    public class Builder : IExpression
    {

        private IExpression current;

        public Builder()
        {

        }

        public Builder(IExpression initial)
        {
            Init(initial);
        }

        public Builder(double number)
        {
            Init(number);
        }

        public Builder(string variable)
        {
            Init(variable);
        }

        public override string ToString()
        {
            return current.ToString();
        }

        public static Builder Create(IExpression initial)
        {
            return new Builder(initial);
        }

        public static Builder Create(double number)
        {
            return new Builder(number);
        }

        public static Builder Create(string variable)
        {
            return new Builder(variable);
        }

        public void Init(IExpression initial)
        {
            this.current = initial;
        }

        public void Init(double number)
        {
            Init((IExpression)new Number(number));
        }

        public void Init(string variable)
        {
            Init((IExpression)new Variable(variable));
        }

        private void CheckCurrentExpression()
        {
            // todo: ???
            if (current == null)
                throw new ArgumentNullException(nameof(current));
        }

        public Builder Expression(Func<IExpression, IExpression> customExpression)
        {
            CheckCurrentExpression();

            current = customExpression(current);

            return this;
        }

        public Builder Add(IExpression summand)
        {
            CheckCurrentExpression();

            current = new Add(current, summand);

            return this;
        }

        public Builder Add(double summand)
        {
            return Add((IExpression)new Number(summand));
        }

        public Builder Add(string summand)
        {
            return Add((IExpression)new Variable(summand));
        }

        public Builder Sub(IExpression subtrahend)
        {
            CheckCurrentExpression();

            current = new Sub(current, subtrahend);

            return this;
        }

        public Builder Sub(double subtrahend)
        {
            return Sub((IExpression)new Number(subtrahend));
        }

        public Builder Sub(string subtrahend)
        {
            return Sub((IExpression)new Variable(subtrahend));
        }

        public Builder Mul(IExpression factor)
        {
            CheckCurrentExpression();

            current = new Mul(current, factor);

            return this;
        }

        public Builder Mul(double factor)
        {
            return Mul((IExpression)new Number(factor));
        }

        public Builder Mul(string factor)
        {
            return Mul((IExpression)new Variable(factor));
        }

        public Builder Div(IExpression denominator)
        {
            CheckCurrentExpression();

            current = new Div(current, denominator);

            return this;
        }

        public Builder Div(double denominator)
        {
            return Div((IExpression)new Number(denominator));
        }

        public Builder Div(string denominator)
        {
            return Div((IExpression)new Variable(denominator));
        }

        public Builder Pow(IExpression exponent)
        {
            CheckCurrentExpression();

            current = new Pow(current, exponent);

            return this;
        }

        public Builder Pow(double exponent)
        {
            return Pow((IExpression)new Number(exponent));
        }

        public Builder Pow(string exponent)
        {
            return Pow((IExpression)new Variable(exponent));
        }

        public Builder Sqrt()
        {
            CheckCurrentExpression();

            current = new Sqrt(current);

            return this;
        }

        public Builder Root(IExpression degree)
        {
            CheckCurrentExpression();

            current = new Root(current, degree);

            return this;
        }

        public Builder Root(double degree)
        {
            return Root((IExpression)new Number(degree));
        }

        public Builder Root(string degree)
        {
            return Root((IExpression)new Variable(degree));
        }

        public Builder Abs()
        {
            CheckCurrentExpression();

            current = new Abs(current);

            return this;
        }

        public Builder Log(IExpression @base)
        {
            CheckCurrentExpression();

            current = new Log(current, @base);

            return this;
        }

        public Builder Log(double number)
        {
            return Log((IExpression)new Number(number));
        }

        public Builder Log(string variable)
        {
            return Log((IExpression)new Variable(variable));
        }

        public Builder Ln()
        {
            CheckCurrentExpression();

            current = new Ln(current);

            return this;
        }

        public Builder Lg()
        {
            CheckCurrentExpression();

            current = new Lg(current);

            return this;
        }

        #region Trigonometric

        public Builder Sin()
        {
            CheckCurrentExpression();

            current = new Sin(current);

            return this;
        }

        public Builder Cos()
        {
            CheckCurrentExpression();

            current = new Cos(current);

            return this;
        }

        public Builder Tan()
        {
            CheckCurrentExpression();

            current = new Tan(current);

            return this;
        }

        public Builder Cot()
        {
            CheckCurrentExpression();

            current = new Cot(current);

            return this;
        }

        public Builder Sec()
        {
            CheckCurrentExpression();

            current = new Sec(current);

            return this;
        }

        public Builder Csc()
        {
            CheckCurrentExpression();

            current = new Csc(current);

            return this;
        }

        public Builder Arcsin()
        {
            CheckCurrentExpression();

            current = new Arcsin(current);

            return this;
        }

        public Builder Arccos()
        {
            CheckCurrentExpression();

            current = new Arccos(current);

            return this;
        }

        public Builder Arctan()
        {
            CheckCurrentExpression();

            current = new Arctan(current);

            return this;
        }

        public Builder Arccot()
        {
            CheckCurrentExpression();

            current = new Arccot(current);

            return this;
        }

        public Builder Arcsec()
        {
            CheckCurrentExpression();

            current = new Arcsec(current);

            return this;
        }

        public Builder Arccsc()
        {
            CheckCurrentExpression();

            current = new Arccsc(current);

            return this;
        }

        #endregion Trigonometric

        #region Hyperbolic

        public Builder Sinh()
        {
            CheckCurrentExpression();

            current = new Sinh(current);

            return this;
        }

        public Builder Cosh()
        {
            CheckCurrentExpression();

            current = new Cosh(current);

            return this;
        }

        public Builder Tanh()
        {
            CheckCurrentExpression();

            current = new Tanh(current);

            return this;
        }

        public Builder Coth()
        {
            CheckCurrentExpression();

            current = new Coth(current);

            return this;
        }

        public Builder Sech()
        {
            CheckCurrentExpression();

            current = new Sech(current);

            return this;
        }

        public Builder Csch()
        {
            CheckCurrentExpression();

            current = new Csch(current);

            return this;
        }

        public Builder Arsinh()
        {
            CheckCurrentExpression();

            current = new Arsinh(current);

            return this;
        }

        public Builder Arcosh()
        {
            CheckCurrentExpression();

            current = new Arcosh(current);

            return this;
        }

        public Builder Artanh()
        {
            CheckCurrentExpression();

            current = new Artanh(current);

            return this;
        }

        public Builder Arcoth()
        {
            CheckCurrentExpression();

            current = new Arcoth(current);

            return this;
        }

        public Builder Arsech()
        {
            CheckCurrentExpression();

            current = new Arsech(current);

            return this;
        }

        public Builder Arcsch()
        {
            CheckCurrentExpression();

            current = new Arcsch(current);

            return this;
        }

        #endregion Hyperbolic

        #region IExpression

        public object Calculate()
        {
            return current.Calculate();
        }

        public object Calculate(ExpressionParameters parameters)
        {
            return current.Calculate(parameters);
        }

        public IExpression Clone()
        {
            return current.Clone();
        }

        public IExpression Parent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MinParameters
        {
            get
            {
                return current.MinParameters;
            }
        }

        public int MaxParameters
        {
            get
            {
                return current.MaxParameters;
            }
        }

        public int ParametersCount
        {
            get
            {
                return current.ParametersCount;
            }
        }

        public ExpressionResultType ResultType
        {
            get
            {
                return current.ResultType;
            }
        }

        #endregion

    }

}