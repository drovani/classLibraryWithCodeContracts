using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Contracts;

namespace ClassLibraryWithContracts.Tests
{
    [TestClass]
    public class ClassWithContractTests
    {
        [TestMethod]
        public void RequiresNonNullString_When_Passed_Null_Throws_Exception()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString(null);

            Assert.IsNull(ret);
        }

        [TestMethod]
        public void RequiresNonNullString_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString("TestString");

            Assert.AreEqual("TestString", ret);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [Ignore]
        public void RequiresNonNullStringGeneric_When_Passed_Null_Throws_ArgumentNullException()
        {
            var ctr = new ClassWithContract();
            ctr.RequiresNonNullStringGeneric(null);
        }

        [TestMethod]
        [Ignore]
        public void RequiresNonNullStringGeneric_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullStringGeneric("TestString");

            Assert.AreEqual("TestString", ret);
        }
    }
}