namespace GOILib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GOILib.Contracts;

    /// <summary>
    /// This factory is responsible for creating an instance of NeighbourRule depending on the Cell Container's type
    /// TODO: Right now it returns a hrad coded instance... the logic to create a configured instance for a given container type still needs to be done.
    /// </summary>
    public class NeighbourRuleFactory : INeighbourRuleFactory
    {
        /// <summary>
        /// Creates an instance of NeighbourRule depending of the CellContainer type
        /// </summary>
        /// <param name="cellContainer">Instance of CellContainer</param>
        /// <returns>Returns an instance of INeighbourRule</returns>
        public INeighbourRule Create(ICellContainer cellContainer)
        {
            // for now return hard coded rule
            return new BasicTwoDimensionalNeighbourCellRule((Grid)cellContainer);
        }
    }
}
