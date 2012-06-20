using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOILib.Tests.Helpers
{
    public static class Utility
    {
        public static int GetAliveCells(Cell[,] cells)
        {
            int alivecount = 0;

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    alivecount += cells[i, j].IsAlive ? 1 : 0;
                }
            }
           return alivecount;
        }
    }
}
