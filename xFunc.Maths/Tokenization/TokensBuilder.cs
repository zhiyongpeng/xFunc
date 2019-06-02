// Copyright 2012-2019 Dmitry Kischenko
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
using System.Numerics;
using xFunc.Maths.Tokenization.Tokens;

namespace xFunc.Maths.Tokenization
{

    /// <summary>
    /// Builder of token list.
    /// </summary>
    public class TokensBuilder
    {

        private readonly IList<IToken> tokens;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokensBuilder"/> class.
        /// </summary>
        public TokensBuilder()
        {
            tokens = new List<IToken>();
        }

        /// <summary>
        /// Adds boolean token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="value">The value of boolean token.</param>
        public TokensBuilder Boolean(bool value)
        {
            tokens.Add(new BooleanToken(value));

            return this;
        }

        /// <summary>
        /// Adds boolean token with <c>true</c> value.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder True()
        {
            tokens.Add(new BooleanToken(true));

            return this;
        }

        /// <summary>
        /// Adds boolean token with <c>false</c> value.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder False()
        {
            tokens.Add(new BooleanToken(false));

            return this;
        }

        /// <summary>
        /// Adds complex token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="complex">The value of complex token.</param>
        public TokensBuilder ComplexNumber(Complex complex)
        {
            tokens.Add(new ComplexNumberToken(complex));

            return this;
        }

        /// <summary>
        /// Adds function token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="function">The type of function.</param>
        /// <param name="countOfParams">The count of parameters.</param>
        public TokensBuilder Function(Functions function, int countOfParams = 1)
        {
            tokens.Add(new FunctionToken(function, countOfParams));

            return this;
        }

        /// <summary>
        /// Adds number token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="number">The value of number token.</param>
        public TokensBuilder Number(double number)
        {
            tokens.Add(new NumberToken(number));

            return this;
        }

        /// <summary>
        /// Adds operation token.
        /// </summary>
        /// <returns>The current instance of builder..</returns>
        /// <param name="operation">The type of operation.</param>
        public TokensBuilder Operation(Operations operation)
        {
            tokens.Add(new OperationToken(operation));

            return this;
        }

        /// <summary>
        /// Adds symbol token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="symbol">The type of symbol.</param>
        public TokensBuilder Symbol(Symbols symbol)
        {
            tokens.Add(new SymbolToken(symbol));

            return this;
        }

        /// <summary>
        /// Adds open brace symbol token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder OpenBrace()
        {
            return Symbol(Symbols.OpenBrace);
        }

        /// <summary>
        /// Adds close brace symbol token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder CloseBrace()
        {
            return Symbol(Symbols.CloseBrace);
        }

        /// <summary>
        /// Adds open bracket symbol token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder OpenBracket()
        {
            return Symbol(Symbols.OpenBracket);
        }

        /// <summary>
        /// Adds close bracket symbol token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder CloseBracket()
        {
            return Symbol(Symbols.CloseBracket);
        }

        /// <summary>
        /// Adds comma symbol token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder Comma()
        {
            return Symbol(Symbols.Comma);
        }

        /// <summary>
        /// Adds user function token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="function">The name of function.</param>
        /// <param name="countOfParams">The count of parameters.</param>
        public TokensBuilder UserFunction(string function, int countOfParams)
        {
            tokens.Add(new UserFunctionToken(function, countOfParams));

            return this;
        }

        /// <summary>
        /// Adds variable token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        /// <param name="variable">The name of variable.</param>
        public TokensBuilder Variable(string variable)
        {
            tokens.Add(new VariableToken(variable));

            return this;
        }

        /// <summary>
        /// Adds the 'x' variable token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder VariableX()
        {
            tokens.Add(new VariableToken("x"));

            return this;
        }

        /// <summary>
        /// Adds the 'y' variable token.
        /// </summary>
        /// <returns>The current instance of builder.</returns>
        public TokensBuilder VariableY()
        {
            tokens.Add(new VariableToken("y"));

            return this;
        }

        /// <summary>
        /// Gets token list. 
        /// </summary>
        /// <value>
        /// The token list.
        /// </value>
        public IList<IToken> Tokens
        {
            get
            {
                return tokens;
            }
        }

    }

}