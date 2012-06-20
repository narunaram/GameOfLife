using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOILib.Contracts
{
    /// <summary>
    /// This contract defines the rule that is responsible for figuring out, who the neighbours are for a given cell.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Neighbour")]
    public interface INeighbourRule
    {
        /// <summary>
        /// This method decides who the neighbours are for a given cell that meets a given specification.
        /// </summary>
        /// <param name="cell">Cells whose neighbour are to be found.</param>
        /// <param name="specification">Specification that should be met by the neighbouring cells.</param>
        /// <returns>Returns the collection of cells that meet the specification</returns>
        ICollection<Cell> FindNeighbours(Cell cell, ISpecification<Cell> specification);
    }
}
