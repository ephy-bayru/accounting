/*
 * @CreateTime: Sep 5, 2018 3:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 3:15 PM
 * @Description: Samrt Accounting Application Layer Test Class 
 */
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