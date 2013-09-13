using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace LevelUp.Extensions.Test
{
    
    
    /// <summary>
    ///This is a test class for StringExtensionTest and is intended
    ///to contain all StringExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringExtensionTest
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
        ///A test for IsNullOrEmpty
        ///</summary>
        [TestMethod()]
        public void IsNullOrEmpty_InputEmptyString_ReturnTrue()
        {
            //arrange
            string str = string.Empty;
            bool expected = true;
            bool actual;

            //act
            actual = StringExtension.IsNullOrEmpty(str);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsNullOrEmpty
        ///</summary>
        [TestMethod()]
        public void IsNullOrEmpty_InputNull_ReturnTrue()
        {
            //arrange
            string str = null;
            bool expected = true;
            bool actual;

            //act
            actual = StringExtension.IsNullOrEmpty(str);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNullOrEmpty_InputUnNullAndEmptyString_ReturnFalse()
        {
            //arrange
            string str = "test123";
            bool expected = false;
            bool actual;

            //act
            actual = StringExtension.IsNullOrEmpty(str);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsMatch
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsMatch_EmptyStringAndEmptyPattern_ThrowArgumentNullException()
        {
            //arrange
            string str = string.Empty;
            string pattern = string.Empty; 
            bool actual;

            //act
            actual = StringExtension.IsMatch(str, pattern);
        }
    }
}
