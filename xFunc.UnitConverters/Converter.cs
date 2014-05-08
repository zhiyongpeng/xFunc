﻿// Copyright 2012-2014 Dmitry Kischenko
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

namespace xFunc.UnitConverters
{

    /// <summary>
    /// The base class for converters.
    /// </summary>
    /// <typeparam name="TUnit">The type that represents units (eg. enum).</typeparam>
    public abstract class Converter<TUnit>
    {

        /// <summary>
        /// The base unit for this convertor.
        /// </summary>
        protected static TUnit BaseUnit;
        /// <summary>
        /// Dictionary of functions to convert from the base unit type into a specific type.
        /// </summary>
        protected static Dictionary<TUnit, Func<double, double>> convTo = new Dictionary<TUnit, Func<double, double>>();
        /// <summary>
        /// Dictionary of functions to convert from the specified type into the base unit type.
        /// </summary>
        protected static Dictionary<TUnit, Func<double, double>> convFrom = new Dictionary<TUnit, Func<double, double>>();

        /// <summary>
        /// Converts a value from one unit type to another.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="from">The unit type the provided value is in.</param>
        /// <param name="to">The unit type to convert the value to.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        public double Convert(double value, TUnit from, TUnit to)
        {
            if (from.Equals(to))
                return value;

            var valueInBaseUnit = from.Equals(BaseUnit) ? value : convFrom[from](value);

            return to.Equals(BaseUnit) ? valueInBaseUnit : convTo[to](valueInBaseUnit);
        }

        /// <summary>
        /// Registers functions for converting to/from a unit.
        /// </summary>
        /// <param name="unit">The type of unit to convert to/from, from the base unit.</param>
        /// <param name="conversionTo">A function to convert from the base unit.</param>
        /// <param name="conversionFrom">A function to convert to the base unit.</param>
        protected static void RegisterConversion(TUnit unit, Func<double, double> conversionTo, Func<double, double> conversionFrom)
        {
            convTo.Add(unit, conversionTo);
            convFrom.Add(unit, conversionFrom);
        }

        /// <summary>
        /// Gets the name of this converter.
        /// </summary>
        /// <value>
        /// The name of this converter.
        /// </value>
        public abstract string Name { get; }

    }

}
