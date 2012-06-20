namespace GOILib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GOILib.Contracts;

    /// <summary>
    /// Provides a basic implementation of a Game Of Life controller
    /// </summary>
    public class BasicGameOfLife:IGameOfLife
    {
        private ICellContainer grid;
        private IEvolutionRuleFactory evolutionaryrulefactory;
        private INeighbourRuleFactory neighbourrulefactory;

        private int generationnumber;

        /// <summary>
        /// Returns the current generation number.
        /// </summary>
        public int GenerationNumber
        {
            get { return generationnumber; }
        }

        /// <summary>
        /// Use this constructor to configure the game of life with the correct neighbour rule and evolution rule factories
        /// </summary>
        /// <param name="grid">Grid of cells to evolve</param>
        /// <param name="evolutionRuleFactory">Factory to create a evolution rule when needed.</param>
        /// <param name="neighbourRuleFactory">Factory to create a neighbour rule when needed.</param>
        public BasicGameOfLife(ICellContainer grid, IEvolutionRuleFactory evolutionRuleFactory, INeighbourRuleFactory neighbourRuleFactory)
        {
            generationnumber = 1;
            this.grid = grid;
            this.evolutionaryrulefactory = evolutionRuleFactory;
            this.neighbourrulefactory = neighbourRuleFactory;
        }

        /// <summary>
        /// Apply a single generation of evolution
        /// </summary>
        public void Evolve()
        {
            IEvolutionRule evolutionrule = GetEvolutionRule();
            Cell evolvedCell = null;

            generationnumber++;

            foreach (Cell cell in grid)
            {
                evolvedCell = evolutionrule.EvolveCell(cell);
                cell.StoreNewState(evolvedCell.IsAlive);
            }
            foreach (Cell cell in grid)
            {
                cell.ApplyNewState();
            }
        }

        private IEvolutionRule GetEvolutionRule()
        {
            INeighbourRule neighbourrule = neighbourrulefactory.Create(grid);
            IEvolutionRule evolutionrule = evolutionaryrulefactory.CreateEvolutionRule(neighbourrule);
            return evolutionrule;
        }
    }
}
