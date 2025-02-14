﻿using System;
using System.Globalization;


namespace EndocPM.WebAPI
{
    public class AppExceptions : Exception
    {
        public AppExceptions() : base() { }

        public AppExceptions(string message) : base(message) { }

        public AppExceptions(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
