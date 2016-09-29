﻿// Copyright 2012-2016 Dmitry Kischenko
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

namespace xFunc.Maths
{
    
    /// <summary>
    /// Defines methods to resolve object for post parse process.
    /// </summary>
    public interface IDependencyResolver
    {

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type for resolving.</param>
        /// <returns>The object of specified type.</returns>
        object Resolve(Type type);
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">The type for resolving.</typeparam>
        /// <returns>The object of specified type.</returns>
        T Resolve<T>() where T : class;

    }

}
