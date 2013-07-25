using System.Linq;
using try_servicestack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for UserServiceTest and is intended
    ///to contain all UserServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserServiceTest
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
        ///test if `name` passed as an argument is a part of firstname or lastname but not some accidental made-up word
        ///</summary>
        [TestMethod()]
        public void HasNameInFirstOrLastTest()
        {
            UserService_Accessor target = new UserService_Accessor();
            Assert.IsTrue(target.HasNameInFirstOrLast("john", new User() { LastName = "JOHNSON" }));
            Assert.IsTrue(target.HasNameInFirstOrLast("jOhn", new User() { FirstName = "JoHn" }));
            Assert.IsFalse(target.HasNameInFirstOrLast("jOhn", new User() { FirstName = "Jo", LastName = "HN"}));
        }


        /// <summary>
        ///A test for FilterUsersByRequestFields
        ///</summary>
        [TestMethod()]
        public void FilterUsersByRequestFieldsTest()
        {
            UserService target = new UserService(); // TODO: Initialize to an appropriate value

            target.DataSource = new[] {
                new User {Email = "jack@mail.com",FirstName = "jack"}, 
                new User {Email = "k@mail.com", LastName = "Sparrow"},
                new User {Email = "ack@mail.com", LastName = "SpaRRow"}};

            Assert.AreEqual(1, target.FilterUsersByRequestFields(new UserRequest(){Email = "ACK@mail.COM"}).Count()); // make sure jack@mail.com won't get there
            Assert.AreEqual(2, target.FilterUsersByRequestFields(new UserRequest() { Name = "SparROW" }).Count()); // make sure jack@mail.com won't get there

        }
    }
}
