// <copyright file="ZenConstantStringExpr.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace ZenLib
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class representing a string constant expression.
    /// </summary>
    internal sealed class ZenConstantStringExpr : Zen<string>
    {
        private static Dictionary<string, Zen<string>> hashConsTable = new Dictionary<string, Zen<string>>();

        public static Zen<string> Create(string value)
        {
            if (hashConsTable.TryGetValue(value, out var v))
            {
                return v;
            }

            var ret = new ZenConstantStringExpr(value);
            hashConsTable[value] = ret;
            return ret;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZenConstantStringExpr"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        private ZenConstantStringExpr(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        internal string Value { get; }

        /// <summary>
        /// Convert the expression to a string.
        /// </summary>
        /// <returns>The string representation.</returns>
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return this.Value;
        }

        /// <summary>
        /// Implementing the visitor interface.
        /// </summary>
        /// <param name="visitor">The visitor object.</param>
        /// <param name="parameter">The visitor parameter.</param>
        /// <typeparam name="TParam">The visitor parameter type.</typeparam>
        /// <typeparam name="TReturn">The visitor return type.</typeparam>
        /// <returns>A return value.</returns>
        internal override TReturn Accept<TParam, TReturn>(IZenExprVisitor<TParam, TReturn> visitor, TParam parameter)
        {
            return visitor.VisitZenConstantStringExpr(this, parameter);
        }
    }
}
