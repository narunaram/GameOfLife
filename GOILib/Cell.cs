namespace GOILib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a single cell in the matrix.
    /// TODO: Can be abstracted into more general interface, so that the cell can represent different states as well as positions.
    /// </summary>
    public class Cell
    {
        private int rownumber;
        public int RowNumber 
        { 
            get{return rownumber;}
        }

        /// <summary>
        /// 
        /// </summary>
        private bool newisalivestate = false;

        /// <summary>
        /// 
        /// </summary>
        private int columnnumber;
        public int ColumnNumber { get { return columnnumber; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnNumber"></param>
        /// <param name="isAlive"></param>
        public Cell(int rowNumber, int columnNumber, bool isAlive)
        {
            rownumber = rowNumber;
            columnnumber = columnNumber;
            IsAlive = isAlive;
        }
    
        /// <summary>
        /// This method sets sets the current state of the Cell to the state it is supposed to evolve to.
        /// </summary>
        public void ApplyNewState()
        {
            IsAlive = newisalivestate;
        }

        /// <summary>
        /// This method sets the new state to whatever the evolved state if
        /// </summary>
        /// <param name="isAlive"></param>
        public void StoreNewState(bool isAlive)
        {
            newisalivestate = isAlive;
        }
    }
}
