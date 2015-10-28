using Slacker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SlackerTest
{


    /// <summary>
    ///This is a test class for TimeEntryTest and is intended
    ///to contain all TimeEntryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TimeEntryTest
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
        ///A test for hours
        ///</summary>
        [TestMethod()]
        public void testHours()
        {
            TimeEntry target = new TimeEntry();
            double expected = 0.0;
            double actual;
            target.hours = expected;
            actual = target.hours;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for description
        ///</summary>
        [TestMethod()]
        public void testDescription()
        {
            TimeEntry target = new TimeEntry();
            string expected = "This is a Simple Testing String";
            string actual;
            target.description = expected;
            actual = target.description;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for day
        ///</summary>
        [TestMethod()]
        public void testDay()
        {
            TimeEntry target = new TimeEntry();
            DateTime expected = new DateTime();
            DateTime actual;
            target.day = expected;
            actual = target.day;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for jobId
        ///</summary>
        [TestMethod()]
        public void testJobId()
        {
            TimeEntry target = new TimeEntry();
            string expected = "T14001";
            string actual;
            target.jobId = expected;
            actual = target.jobId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TimeEntry Constructor
        ///</summary>
        [TestMethod()]
        public void TimeEntryConstructorTest()
        {
            TimeEntry target = new TimeEntry();
            Assert.AreEqual(target.description, String.Empty);
            Assert.AreEqual(target.jobId, String.Empty);
            Assert.AreEqual(target.hours, 0.0);
            Assert.AreEqual(target.day.Date, DateTime.Today);
        }

        /// <summary>
        ///A test for hours
        ///</summary>
        [TestMethod()]
        public void testAcceptableHours()
        {
            TimeEntry target = new TimeEntry();

            target.hours = -0.25;
            Assert.AreEqual(target.hours, 0);

            target.hours = 24.25;
            Assert.AreEqual(target.hours, 0);
        }
    }
}
