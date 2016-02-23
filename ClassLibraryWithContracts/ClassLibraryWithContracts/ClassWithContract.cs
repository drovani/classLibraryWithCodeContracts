using System;
using System.Diagnostics.Contracts;

namespace ClassLibraryWithContracts
{
    public class ClassWithContract
    {
        public string RequiresNonNullString(string arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<string>() == arg);

            return arg;
        }
        public string RequiresNonNullStringGeneric(string arg)
        {
            Contract.Requires<ArgumentNullException>(arg != null);
            Contract.Ensures(Contract.Result<string>() == arg);

            return arg;
        }
    }
}
