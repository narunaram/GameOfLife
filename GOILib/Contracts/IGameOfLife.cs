using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOILib.Contracts
{
    /// <summary>
    /// Defines the contract for a Game of life controller.
    /// </summary>
    public interface IGameOfLife
    {
        /// <summary>
        /// Method to apply a single generation of evolution.
        /// </summary>
        void Evolve();

        /// <summary>
        /// Reads the current generation at any given point of time.
        /// </summary>
        int GenerationNumber
        {
            get;
        }
    }
}
