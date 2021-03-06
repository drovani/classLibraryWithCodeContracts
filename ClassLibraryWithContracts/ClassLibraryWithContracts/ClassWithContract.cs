﻿using System;
using System.Diagnostics.Contracts;

namespace ClassLibraryWithContracts
{
    public class ClassWithContract
    {
        public string RequiresNonNullString(string arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<string>() == arg);
            Contract.Ensures(Contract.Result<string>() != null);

            return arg;
        }

        public string RequiresNonNullString_Generic(string arg)
        {
            Contract.Requires<ArgumentNullException>(arg != null);
            Contract.Ensures(Contract.Result<string>() == arg);
            Contract.Ensures(Contract.Result<string>() != null);

            return arg;
        }
    }
}
