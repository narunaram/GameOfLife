using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOILib
{
    /// <summary>
    /// Provides an enumrator for the cells contained in a Grid. It enumrates the cells from left to right and then moves down to the next row.
    /// </summary>
    public sealed class GridCellEnumerator:IEnumerator<Cell>
    {
        private Grid grid;
        private int currentrow = 0;
        private int currentcol = -1;

        public GridCellEnumerator(Grid grid)
        {
            this.grid = grid;
        }

        #region IEnumerator members
        public Cell Current
        {
            get { return grid[currentrow, currentcol]; }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            bool retval;
            if (currentrow >= grid.RowCount - 1 && currentcol >= grid.ColumnCount - 1)
            {
                retval = false;
            }
            else
            {
                currentcol++;
                if (currentcol == grid.ColumnCount)
                {
                    currentrow++;
                    currentcol = 0;
                }
                retval = true;
            }
            return retval;
        }

        public void Reset()
        {
            currentcol = -1;
            currentrow = 0;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        #endregion
    }
}
