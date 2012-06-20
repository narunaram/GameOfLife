namespace GOILib.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contract of the evolution Rule that is responsible for apply the business rules for evolution of a given cell.
    /// </summary>
    public interface IEvolutionRule
    {
        /// <summary>
        /// This method evolves the cell according to the rules and returns a new cell with the new state.
        /// </summary>
        /// <param name="cell">Cell to evolve.</param>
        /// <returns>Returns the cell with the state after evolution.</returns>
        Cell EvolveCell(Cell cell);
    }
}
