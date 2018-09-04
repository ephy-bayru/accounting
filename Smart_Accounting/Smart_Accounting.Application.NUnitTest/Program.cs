using System;
using System.Reflection;
using NUnitLite;

namespace Smart_Accounting.Application.NUnitTest {
    class Program {
        static int Main (string[] args) {
            var typeInfo = typeof (Program).GetTypeInfo ();
            return new AutoRun (typeInfo.Assembly).Execute (args);
        }
    }
}