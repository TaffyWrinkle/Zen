﻿// <copyright file="ModelCheckerEnvironment.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Research.Zen.ModelChecking
{
    using System.Collections.Immutable;

    /// <summary>
    /// An environment for the symbolic evaluator.
    /// </summary>
    internal class SymbolicEvaluationEnvironment<TModel, TVar, TBool, TInt>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolicEvaluationEnvironment{TModel, TVar, TBool, TInt}"/> class.
        /// </summary>
        public SymbolicEvaluationEnvironment()
        {
            this.ArgumentAssignment = ImmutableDictionary<string, SymbolicValue<TModel, TVar, TBool, TInt>>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolicEvaluationEnvironment{TModel, TVar, TBool, TInt}"/> class.
        /// </summary>
        /// <param name="argumentAssignment">The initial argument assignment.</param>
        public SymbolicEvaluationEnvironment(ImmutableDictionary<string, SymbolicValue<TModel, TVar, TBool, TInt>> argumentAssignment)
        {
            this.ArgumentAssignment = argumentAssignment;
        }

        /// <summary>
        /// Gets the argument assignment.
        /// </summary>
        public ImmutableDictionary<string, SymbolicValue<TModel, TVar, TBool, TInt>> ArgumentAssignment { get; }
    }
}