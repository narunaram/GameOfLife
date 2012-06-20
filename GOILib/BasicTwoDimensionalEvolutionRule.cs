using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOILib.Contracts;

namespace GOILib
{
    /// <summary>
    /// Implementation of rule that decides how a given cell would evolve.
    /// </summary>
    public class BasicTwoDimensionalEvolutionRule:IEvolutionRule
    {
        INeighbourRule neighbourRule;

        // Instance of a specification that defines a cell as being alive
        static ISpecification<Cell> aliveSpecification = new AliveSpecification();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="neighbourRule"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "neighbour")]
        public BasicTwoDimensionalEvolutionRule(INeighbourRule neighbourRule)
        {
            this.neighbourRule = neighbourRule;
        }

        /// <summary>
        /// Evolves the cell by applying the evolution rules.
        /// </summary>
        /// <param name="cell">Cell to evolve.</param>
        /// <returns>Returns the evolved cell.</returns>
        public Cell EvolveCell(Cell cell)
        {
            if(cell == null)
            {
                throw new ArgumentNullException(paramName:"Cell");
            }
            Cell evolvedcell = new Cell(cell.RowNumber, cell.ColumnNumber, false);
            int aliveneighbours = neighbourRule.FindNeighbours(cell, aliveSpecification).Count;
            
            if ((cell.IsAlive && (aliveneighbours == 2 || aliveneighbours == 3)) || (!cell.IsAlive) && aliveneighbours == 3)
            {
                evolvedcell.IsAlive = true;
            }
            return evolvedcell;
        }
    }
}
