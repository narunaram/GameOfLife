using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOILib.Contracts;

namespace GOILib
{
    /// <summary>
    /// Provides the specification of a cell being alive
    /// </summary>
    public class AliveSpecification:ISpecification<Cell>
    {
        /// <summary>
        /// Use this method to check if a cell meets the cpecification of being alive
        /// </summary>
        /// <param name="obj">The Cell to be checked.</param>
        /// <returns>Returns true if the Cell is alive, else returns false.</returns>
        public bool IsSatisfiedBy(Cell obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException( paramName:"Cell");
            }

            return obj.IsAlive;
        }
    }
}
