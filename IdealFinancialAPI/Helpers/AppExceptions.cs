﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Helpers
{
    public class AppExceptions : Exception
    {
        public AppExceptions() : base() { }

        public AppExceptions(string message) : base(message) { }
    }
}
