namespace GOILib.Contracts
{
    using System;

    /// <summary>
    /// Defines the contract for creating the correct instance of INeighbourRule
    /// </summary>
    public interface INeighbourRuleFactory
    {
        /// <summary>
        /// Creates an instance of NeighbourRule depending of the CellContainer type
        /// </summary>
        /// <param name="cellContainer">Instance of CellContainer</param>
        /// <returns>Returns an instance of INeighbourRule</returns>
        INeighbourRule Create(ICellContainer cellContainer);
    }
}
