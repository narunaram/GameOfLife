using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOILib.Tests.Helpers
{
    /// <summary>
    /// Static class that provides pre-configured grid with different configurations.
    /// </summary>
    public static class GridInitializationHelper
    {
        public static Grid Get4By4gridWithAllDeadCells()
        {
            return new Grid(4, 4);
        }

        public static Grid Get4By4gridWithTopLeftAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 0].IsAlive = true;
            return grid;
        }

        public static Grid Get4By4gridWithTopEdgeCellsAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 0].IsAlive = true;
            grid[0, 1].IsAlive = true;
            grid[0, 2].IsAlive = true;
            grid[0, 3].IsAlive = true;
            return grid;
        }

        public static Grid Get4By4gridWithTopEdgeThreeLeftCellsAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 0].IsAlive = true;
            grid[0, 1].IsAlive = true;
            grid[0, 2].IsAlive = true;
            return grid;
        }

        public static Grid Get4By4gridWithMiddleCellDeadAnd3DiagonalNeighboursAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 0].IsAlive = true;
            grid[0, 2].IsAlive = true;
            grid[2, 2].IsAlive = true;
            return grid;
        }

        public static Grid Get4By4gridWithMiddleCellDeadAnd2NeighboursAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 0].IsAlive = true;
            grid[0, 2].IsAlive = true;
            return grid;
        }

        public static Grid Get4By4gridWithMiddleCellDeadAnd1NeighboursAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 2].IsAlive = true;
            return grid;
        }

        public static Grid Get4By4gridWithMiddleCellDeadAnd4NeighboursAlive()
        {
            Grid grid = Get4By4gridWithAllDeadCells();
            grid[0, 0].IsAlive = true;
            grid[0, 1].IsAlive = true;
            grid[1, 0].IsAlive = true;
            grid[0, 2].IsAlive = true;
            return grid;
        }
    }
}
