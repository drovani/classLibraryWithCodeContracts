using System;
using System.Diagnostics.Contracts;
using Xunit;

namespace ClassLibraryWithContracts.Tests
{
    public class ClassWithContractTests
    {
        public ClassWithContractTests()
        {
            Contract.ContractFailed += (sender, e) =>
            {
                e.SetHandled();
                e.SetUnwind();

                throw new Exception(e.FailureKind + ": " + e.Message);
            };
        }

        [Fact(Skip = "Unabled to get Contract.Requires(...) to raise ContractFailed event.")]
        public void RequiresNonNullString_When_Passed_Null_Throws_Exception()
        {
            var ctr = new ClassWithContract();
            Assert.ThrowsAny<Exception>(() => ctr.RequiresNonNullString(null));
        }

        [Fact]
        public void RequiresNonNullString_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullString("TestString");

            Assert.Equal("TestString", ret);
        }
        [Fact(Skip = "Tests Contract.Requires<TException>")]
        public void RequiresNonNullStringGeneric_When_Passed_Null_Throws_ArgumentNullException()
        {
            var ctr = new ClassWithContract();
            Assert.ThrowsAny<Exception>(() => ctr.RequiresNonNullStringGeneric(null));
        }

        [Fact]
        public void RequiresNonNullStringGeneric_Returns_String_When_NotEmpty()
        {
            var ctr = new ClassWithContract();
            string ret = ctr.RequiresNonNullStringGeneric("TestString");

            Assert.Equal("TestString", ret);
        }
    }
}