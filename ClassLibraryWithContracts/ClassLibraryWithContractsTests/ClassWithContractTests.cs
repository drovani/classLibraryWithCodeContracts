using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Contracts;

namespace ClassLibraryWithContracts.Tests
{
    [TestClass]
    public class ClassWithContractTests
    {
        [TestMethod]
        public void RequiresNonNullString_When_Passed_Null_Fires_ContractFailed()
        {
            bool contractFailed = false;
            Contract.ContractFailed += (o, e) =>
            {
                e.SetHandled();
                contractFailed = true;
            };

            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString(null);
            Assert.IsTrue(contractFailed);
        }

        [TestMethod]
        public void RequiresNonNullString_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString("TestString");

            Assert.AreEqual("TestString", ret);
        }

        [TestMethod]
        public void RequiresNonNullString_Generic_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString_Generic("TestString");

            Assert.AreEqual("TestString", ret);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresNonNullString_Generic_When_Passed_Null_Throws_Exception()
        {
            Contract.ContractFailed += (o, e) =>
            {
                e.SetHandled();
            };

            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString_Generic(null);
        }
    }
}