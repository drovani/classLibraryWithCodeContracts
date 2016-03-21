using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;

namespace ClassLibraryWithContracts.Tests
{
    [TestClass]
    public class ClassWithContractTests
    {
        [TestMethod]
        public void RequiresNonNullString_When_Passed_Null_Throws_Exception()
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
    }
}