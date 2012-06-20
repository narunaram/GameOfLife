namespace GOILib.Contracts
{
    using System;

    /// <summary>
    /// Defines the contract for a factory that knows how to create the correct instance of Evolution Rule
    /// </summary>
    public interface IEvolutionRuleFactory
    {
        /// <summary>
        /// Create the correct instance of an evolution rule.
        /// </summary>
        /// <param name="neighbourRule">Instance of neighbour rule that the evolution rule is configured with.</param>
        /// <returns>Returns an instance of newly created Evolution Rule.</returns>
        IEvolutionRule CreateEvolutionRule(GOILib.Contracts.INeighbourRule neighbourRule);
    }
}
