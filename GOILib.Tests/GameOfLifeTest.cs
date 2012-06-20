namespace GOILib.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GOILib;
    using GOILib.Tests.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using GOILib.Contracts;

    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void GOI_Evolve_EvolvesAllTheCells()
        {
            int callcount = 0;
            var mockevolutionrule = new Mock<IEvolutionRule>();
            mockevolutionrule.Setup(rule => rule.EvolveCell(It.IsAny<Cell>())).Returns((Cell cell) => cell).Callback(() => callcount++);

            var mockneighbourrule = new Mock<INeighbourRule>();

            var mockneighbourrulefactory = new Mock<INeighbourRuleFactory>();
            mockneighbourrulefactory.Setup(nf => nf.Create(It.IsAny<ICellContainer>())).Returns(() => mockneighbourrule.Object);

            var mockevolutionrulefactory = new Mock<IEvolutionRuleFactory>();
            mockevolutionrulefactory.Setup(e => e.CreateEvolutionRule(It.IsAny<INeighbourRule>())).Returns(() => mockevolutionrule.Object);

            Grid grid = GridInitializationHelper.Get4By4gridWithAllDeadCells();

            BasicGameOfLife gameoflife = new BasicGameOfLife(grid, mockevolutionrulefactory.Object, mockneighbourrulefactory.Object);
            gameoflife.Evolve();

            Assert.AreEqual(16, callcount);
            Assert.AreEqual(2, gameoflife.GenerationNumber);
        }
    }
}
