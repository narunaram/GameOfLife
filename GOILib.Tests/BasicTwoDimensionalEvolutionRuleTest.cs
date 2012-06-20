using GOILib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GOILib.Contracts;
using Moq;
using System.Collections.Generic;

namespace GOILib.Tests
{
    /// <summary>
    ///This is a test class for BasicTwoDimensionalEvolutionRuleTest and is intended
    ///to contain all BasicTwoDimensionalEvolutionRuleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BasicTwoDimensionalEvolutionRuleTest
    {
        private TestContext testContextInstance;
        private static Cell alivecell;
        private static Cell deadcell;
        private static Mock<INeighbourRule> mockneighbourrule = new Mock<INeighbourRule>();

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            alivecell = new Cell(0, 0, true);
            deadcell = new Cell(0, 0, false);
        }
        #endregion

        #region private helper methods
        private void SetupNeighbourMockReturnValue(int retValue)
        {
            List<Cell> cells = new List<Cell>();
            for (int i = 0; i < retValue; i++ )
            {
                cells.Add(new Cell(0,0,false)); // We are only concerned with the count and not the actual cells
            }
            mockneighbourrule.Setup(r => r.FindNeighbours(It.IsAny<Cell>(), It.IsAny<ISpecification<Cell>>())).Returns(cells);
        }
        #endregion

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void LiveCell_WithLessThan2LiveNeighbours_Dies()
        {
            SetupNeighbourMockReturnValue(1);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(alivecell);
            Assert.AreEqual(cell.IsAlive, false);
        }

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void LiveCell_With2LiveNeighbours_Survives()
        {
            SetupNeighbourMockReturnValue(2);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(alivecell);
            Assert.AreEqual(cell.IsAlive, true);
        }

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void LiveCell_With3LiveNeighbours_Survives()
        {
            SetupNeighbourMockReturnValue(3);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(alivecell);
            Assert.AreEqual(cell.IsAlive, true);
        }

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void LiveCell_WithMoreThan3LiveNeighbours_Dies()
        {
            SetupNeighbourMockReturnValue(4);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(alivecell);
            Assert.AreEqual(cell.IsAlive, false);
        }

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void DeadCell_With3LiveNeighbours_IsBorn()
        {
            SetupNeighbourMockReturnValue(3);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(deadcell);
            Assert.AreEqual(cell.IsAlive, true);
        }

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void DeadCell_WithLessThan3LiveNeighbours_RemainsDead()
        {
            SetupNeighbourMockReturnValue(2);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(deadcell);
            Assert.AreEqual(cell.IsAlive, false);
        }

        /// <summary>
        ///A test for EvolveCell
        ///</summary>
        [TestMethod()]
        public void DeadCell_WithGreaterThan3LiveNeighbours_RemainsDead()
        {
            SetupNeighbourMockReturnValue(4);
            BasicTwoDimensionalEvolutionRule evolutionrule = new BasicTwoDimensionalEvolutionRule(mockneighbourrule.Object);
            Cell cell = evolutionrule.EvolveCell(deadcell);
            Assert.AreEqual(cell.IsAlive, false);
        }
    }
}
