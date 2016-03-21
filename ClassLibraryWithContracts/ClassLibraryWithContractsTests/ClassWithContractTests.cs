using System;
using System.Diagnostics.Contracts;
using Xunit;

namespace ClassLibraryWithContracts.Tests
{
    public class ClassWithContractTests
    {
        [Fact]
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
            Assert.True(contractFailed);
        }

        [Fact]
        public void RequiresNonNullString_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString("TestString");

            Assert.Equal("TestString", ret);
        }

        [Fact]
        public void RequiresNonNullString_Generic_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString_Generic("TestString");

            Assert.Equal("TestString", ret);
        }

        [Fact]
        public void RequiresNonNullString_Generic_When_Passed_Null_Throws_Exception()
        {
            Contract.ContractFailed += (o, e) =>
            {
                e.SetHandled();
            };

            var ctr = new ClassWithContract();
            Assert.Throws<ArgumentNullException>(() => ctr.RequiresNonNullString_Generic(null));
        }
    }
}