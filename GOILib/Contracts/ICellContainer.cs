using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOILib.Contracts
{
    /// <summary>
    /// Defines a contract that can be used by any implementation to act as a container of cells.
    /// One could have a container that provides a 3 dimensional view of the Cells.. or a 2 dimensional view of the cells etc.
    /// </summary>
    public interface ICellContainer
    {
        IEnumerator<Cell> GetEnumerator();
    }
}
