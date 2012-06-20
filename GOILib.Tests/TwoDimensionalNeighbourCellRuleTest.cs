namespace GOILib.Tests
{
    using System;
    using GOILib;
    using GOILib.Contracts;
    using GOILib.Tests.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    ///This is a test class for TwoDimensionalNeighbourCellRuleTest and is intended
    ///to contain all TwoDimensionalNeighbourCellRuleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TwoDimensionalNeighbourCellRuleTest
    {
        private TestContext testContextInstance;
        private static Grid grid;
        private static BasicTwoDimensionalNeighbourCellRule rule;

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
            grid = GridInitializationHelper.Get4By4gridWithAllDeadCells();
            rule = new BasicTwoDimensionalNeighbourCellRule(grid);
        }
        #endregion

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void TopLeftCellNeighboursfor_4By4Grid_Is3()
        {
            int target = 3;
            int actual = rule.FindNeighbours(grid[0,0], null).Count;
            Assert.AreEqual(target, actual);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void BottomRightCellNeighboursfor_4By4Grid_Is3()
        {
            int target = 3;
            int actual = rule.FindNeighbours(grid[3, 3], null).Count;
            Assert.AreEqual(target, actual);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void TopRightCellNeighboursfor_4By4Grid_Is3()
        {
            int target = 3;
            int actual = rule.FindNeighbours(grid[0, 3], null).Count;
            Assert.AreEqual(target, actual);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void BottomLeftCellNeighboursfor_4By4Grid_Is3()
        {
            int target = 3;
            int actual = rule.FindNeighbours(grid[3, 0], null).Count;
            Assert.AreEqual(target, actual);
        }


        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void TopSecondCellNeighboursfor_4By4Grid_Is5()
        {
            int target = 5;
            int actual = rule.FindNeighbours(grid[0, 1], null).Count;
            Assert.AreEqual(target, actual);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void BottomSecondCellNeighboursfor_4By4Grid_Is5()
        {
            int target = 5;
            int actual = rule.FindNeighbours(grid[3, 1], null).Count;
            Assert.AreEqual(target, actual);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void SecondRowColumnCellNeighboursfor_4By4Grid_Is8()
        {
            int target = 8;
            int actual = rule.FindNeighbours(grid[1, 1], null).Count;
            Assert.AreEqual(target, actual);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void SpecificationOnNeighbours_IscorrectlyApplied()
        {
            int callcount = 0;
            var mockspecification = new Mock<ISpecification<Cell>>();
            mockspecification.Setup(s => s.IsSatisfiedBy(It.IsAny<Cell>())).Returns(true).Callback(()=> callcount++);
            int target = 8;
            int actual = rule.FindNeighbours(grid[1, 1], mockspecification.Object).Count;
            Assert.AreEqual(target, callcount);
        }
    }
}
