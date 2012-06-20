using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOILib.Contracts;

namespace GOILib
{
    /// <summary>
    /// This is a container for storing cells in a 2 dimenionsional matrix.
    /// The class encapsulates the internal structure in which the cells are stored.
    /// </summary>
    public class Grid:ICellContainer
    {
        private Cell[][] cells;

        private int rowCount;
        public int RowCount
        {
            get { return rowCount; }
        }

        private int columnCount;
        public int ColumnCount
        {
            get { return columnCount; }
        }

        /// <summary>
        /// Use this to create a grid with a given number of rows and columns.
        /// A limit of 1 Lakh rows and columns has been choosen at random.
        /// </summary>
        /// <param name="rowCount">The number of rows to create</param>
        /// <param name="columnCount">The number of columns to create</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
        public Grid(int rowCount, int columnCount)
        {
            if ((rowCount <= 0 || columnCount <= 0) && (rowCount> 100000 || columnCount> 100000))
            {
                throw new ArgumentOutOfRangeException("The rowCount and columnCount should be greater than 0 and less than 100000.");
            }

            this.rowCount = rowCount;
            this.columnCount = columnCount;

            cells = new Cell[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                cells[i] = new Cell[columnCount];
                for (int j = 0; j < columnCount; j++)
                {
                    cells[i][j] = new Cell(i, j, false);
                }
            }
        }

        /// <summary>
        /// This indexer provides a quick way to get to a cell given int's row and column number
        /// </summary>
        /// <param name="rowNumber">Row number of the cell.</param>
        /// <param name="colNumber">Column number of the cell.</param>
        /// <returns>Returns the cell</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
        public Cell this[int rowNumber, int colNumber]
        {
            get
            {
                if (colNumber < 0 || rowNumber < 0 || colNumber >= columnCount || rowNumber >= rowCount)
                {
                    throw new ArgumentOutOfRangeException("The rowNumber and columnNumber values should be within the dimensions of the Grid.");
                }
                return cells[rowNumber][colNumber];
            }
        }

        /// <summary>
        /// Returns an inumerator that can be used for enumeration through the cells contained in the grid
        /// </summary>
        /// <returns>Returns an enumrator</returns>
        public IEnumerator<Cell> GetEnumerator()
        {
            return new GridCellEnumerator(this);
        }
    }
}
