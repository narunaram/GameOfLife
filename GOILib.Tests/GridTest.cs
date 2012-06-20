namespace GOILib.Tests
{
    using GOILib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using GOILib.Tests.Helpers;    
    
    /// <summary>
    ///This is a test class for GridTest and is intended
    ///to contain all GridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridTest
    {
        private TestContext testContextInstance;
        private static Grid grid;

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
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            grid = GridInitializationHelper.Get4By4gridWithAllDeadCells();
        }
        #endregion

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void Grid4By4_Enumerates_16Times()
        {
            int count = 0;
            foreach (Cell cell in grid)
            {
                count++;
            }

            Assert.AreEqual(16, count);
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void Grid2By2_Enumerates_4Times()
        {
            int count = 0;
            Grid grid = new Grid(2, 2);
            foreach (Cell cell in grid)
            {
                count++;
            }

            Assert.AreEqual(4, count);
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void Grid1By1Enumerates_1Time()
        {
            int count = 0;
            Grid grid = new Grid(1, 1);
            foreach (Cell cell in grid)
            {
                count++;
            }

            Assert.AreEqual(1, count);
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void Grid1By4Enumerates_4Times()
        {
            int count = 0;
            Grid grid = new Grid(1, 4);
            foreach (Cell cell in grid)
            {
                count++;
            }

            Assert.AreEqual(4, count);
        }

    }
}
