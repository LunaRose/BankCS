using System;
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for BankAccountTest and is intended
    ///to contain all BankAccountTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BankAccountTest
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
        ///A test for Credit
        ///</summary>
        [TestMethod()]
        public void CreditTest()
        {
            var target = new BankAccount("Mr Brian Walton", 11.99);
            const double amount = 0.01;
            target.Credit(amount);
            Assert.AreEqual(12.00, target.Balance);
        }

        /// <summary>
        ///A test for Debit
        ///</summary>
        [TestMethod()]
        public void DebitTest()
        {
            var target = new BankAccount("Mr Brian Walton", 11.99);
            const double amount = 11.22; 
            target.Debit(amount);
            Assert.AreEqual(0.77, target.Balance, 0.05);
        }

        /// <summary>
        ///A test for FreezeAccount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("BankCS.dll")]
        public void FreezeAccountTest()
        {
            var target = new BankAccount_Accessor("Mr Brian Walton", 11.99);
            target.FreezeAccount();

            var creditAccount = true;

            try
            {
                target.Credit(1.00);
            }
            catch (Exception)
            {
                creditAccount = false;
            }

            Assert.IsFalse(creditAccount, "Was not able to credit account.");
        }

        /// <summary>
        ///A test for UnfreezeAccount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("BankCS.dll")]
        public void UnfreezeAccountTest()
        {
            var target = new BankAccount_Accessor("Mr Brian Walton", 11.99);
            target.FreezeAccount();
            Assert.IsTrue(target.frozenValue);
            target.UnfreezeAccount();

            var creditAccount = true;

            try
            {
                target.Credit(1.00);
            }
            catch (Exception)
            {
                creditAccount = false;
            }

            Assert.IsTrue(creditAccount, "Was able to credit account.");
        }
    }
}
