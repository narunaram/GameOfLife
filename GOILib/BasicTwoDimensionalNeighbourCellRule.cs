using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOILib.Contracts;

namespace GOILib
{
    /// <summary>
    /// Implements the rule for finding the neighbours of a cell in a 2 dimensional matrix contained in a Grid.
    /// </summary>
    public class BasicTwoDimensionalNeighbourCellRule:INeighbourRule
    {
        private Grid grid;

        /// <summary>
        /// In order to find the neighbours of a given cell in an optimized way, the rule must be aware of the structure in which it is contained.
        /// Hence there is a tight coupling between an implementation of a neighbour rule and a CellContainer.
        /// This implementation depends on the cells being contained in a Grid.
        /// </summary>
        /// <param name="grid">The Grid of cells</param>
        public BasicTwoDimensionalNeighbourCellRule(Grid grid)
        {
            this.grid = grid;
        }

        /// <summary>
        /// Finds the number of neighbours of a given cell that meet the passed in specification.
        /// </summary>
        /// <param name="cell">Cell whose neighbours have to be found.</param>
        /// <param name="specification">The specification that should be met by the neighbouring cells.</param>
        /// <returns>Returns the collection of cells that meet the passed in specification.</returns>
        public ICollection<Cell> FindNeighbours(Cell cell, ISpecification<Cell> specification)
        {
            List<Cell> cells = new List<Cell>();
            if (cell == null)
            {
                throw new ArgumentNullException(paramName:"Cell");
            }

            int column = cell.ColumnNumber;
            int row = cell.RowNumber;
            int startrow;
            int startcol;
            int endcol;
            int endrow;
            GetValidStartRowAndColumn(row, column, out startrow, out startcol);
            GetValidEndRowAndColumn(row, column, out endrow, out endcol);

            for (int xcoord = startrow; xcoord <= endrow; xcoord++)
            {
                for (int ycoord = startcol; ycoord <= endcol; ycoord++)
                {
                    if (!(xcoord == row && ycoord == column))
                    {
                        if (specification == null)
                            cells.Add(grid[xcoord, ycoord]);
                        else
                            if(specification.IsSatisfiedBy(grid[xcoord, ycoord]))
                                cells.Add(grid[xcoord, ycoord]);
                    }
                }
            }
            return cells;
        }

        /// <summary>
        /// Figures out the indexes from which to start scanning
        /// </summary>
        /// <param name="row">row number of the cell</param>
        /// <param name="column">column number of the cell</param>
        /// <param name="startrow">starting row to scan from</param>
        /// <param name="startcolumn">starting column to scan from</param>
        internal static void GetValidStartRowAndColumn(int row, int column, out int startrow, out int startcolumn)
        {
            startrow = row > 0 ? row - 1 : 0;
            startcolumn = column > 0 ? column - 1 : 0;
        }

        /// <summary>
        /// Figures out the indexes from which to end scanning
        /// </summary>
        /// <param name="row">row number of the cell</param>
        /// <param name="column">column number of the cell</param>
        /// <param name="endrow">last row to scan till</param>
        /// <param name="endcolumn">last column to scan till</param>
        internal void GetValidEndRowAndColumn(int row, int column, out int endrow, out int endcolumn)
        {
            endcolumn = column + 1 < grid.ColumnCount ? column + 1 : grid.ColumnCount - 1;
            endrow = row + 1 < grid.RowCount ? row + 1 : grid.RowCount - 1;
        }
    }
}
