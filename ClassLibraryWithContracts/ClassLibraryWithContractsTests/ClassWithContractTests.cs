using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Contracts;

namespace ClassLibraryWithContracts.Tests
{
    [TestClass]
    public class ClassWithContractTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void RequiresNonNullString_When_Passed_Null_Throws_Exception()
        {
            var ctr = new ClassWithContract();
            ctr.RequiresNonNullString(null);
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
        public void RequiresNonNullStringGeneric_When_Passed_Null_Throws_ArgumentNullException()
        {
            var ctr = new ClassWithContract();
            ctr.RequiresNonNullStringGeneric(null);
        }

        [TestMethod]
        public void RequiresNonNullStringGeneric_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullStringGeneric("TestString");

            Assert.AreEqual("TestString", ret);
        }
    }
}