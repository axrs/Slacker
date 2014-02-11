using Slacker.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Slacker;
using System.Collections.Generic;

namespace SlackerTest
{


    /// <summary>
    ///This is a test class for CSVDAOTest and is intended
    ///to contain all CSVDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CSVDAOTest
    {


        private TestContext testContextInstance;

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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CSVDAO Constructor
        ///</summary>
        [TestMethod()]
        public void testEmptyConstructor()
        {
            string file = string.Empty;
            CSVDAO target = new CSVDAO(file);
            Assert.AreEqual(target.file, string.Empty);
        }

        /// <summary>
        ///A test for CSVDAO Constructor
        ///</summary>
        [TestMethod()]
        public void testConstructor()
        {
            string file = "C:\\Test.csv";
            CSVDAO target = new CSVDAO(file);
            Assert.AreEqual(target.file, file);
        }


        /// <summary>
        ///A test for execute
        ///</summary>
        [TestMethod()]
        public void testExecute()
        {
            string file = string.Empty;
            CSVDAO target = new CSVDAO(file);
            Assert.AreEqual(target.execute(), false);
        }

        /// <summary>
        ///A test for getTimes
        ///</summary>
        [TestMethod()]
        public void testDefaultTimesContainer()
        {
            string file = string.Empty;
            CSVDAO target = new CSVDAO(file);
            Assert.AreEqual(target.getTimes().Count, 0);
        }

        /// <summary>
        ///A test for loadTimes
        ///</summary>
        [TestMethod()]
        public void loadTimesTest()
        {
            string file = string.Empty;
            CSVDAO target = new CSVDAO(file);
            target.FileHandler = new ManicTimeCSVMockFile();
            target.loadTimes();
            Assert.AreEqual(8, target.count);
        }

        /// <summary>
        ///A test for processEntry
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Slacker.exe")]
        public void testProcessEntry()
        {
            CSVDAO_Accessor target = new CSVDAO_Accessor("C:\\JunkTestPath");
            string line = "\"B14101\",\"C/F Shading\",\"0.25\",\"0.25\"";
            TimeEntry_Accessor actual = target.processEntry(line);

            Assert.AreEqual(actual._day.Date, DateTime.Today.Date);
            Assert.AreEqual(actual.hours, 0.25);
            Assert.AreEqual(actual.jobId, "B14101");
            Assert.AreEqual(actual.description, "C/F Shading");
        }

        /// <summary>
        ///A test for processFirstLine
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Slacker.exe")]
        public void testProcessFirstLine()
        {
            CSVDAO_Accessor target = new CSVDAO_Accessor("C:\\JunkTestPath");

            string line = "\"Tag 1\",\"Notes\",\"10/02/2014\",\"Total\"";
            DateTime expected = Convert.ToDateTime("10/02/2014");
            DateTime actual = target.processFirstLine(line);

            Assert.AreEqual(expected.Date, actual.Date);
        }

        /// <summary>
        ///A test for count
        ///</summary>
        [TestMethod()]
        public void testDefaultCount()
        {
            string file = string.Empty;
            CSVDAO target = new CSVDAO(file);
            Assert.AreEqual(0, target.count);
        }

        /// <summary>
        ///A test for file
        ///</summary>
        [TestMethod()]
        public void testFile()
        {
            string file = string.Empty; // TODO: Initialize to an appropriate value
            CSVDAO target = new CSVDAO(file); // TODO: Initialize to an appropriate value
            Assert.AreEqual(target.file, string.Empty);

            target.file = "SomeFile";
            Assert.AreEqual(target.file, "SomeFile");
        }
    }
}
