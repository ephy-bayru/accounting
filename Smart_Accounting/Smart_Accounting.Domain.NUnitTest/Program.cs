/*
 * @CreateTime: Sep 4, 2018 12:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 12:25 PM
 * @Description: Finance System Database Entities Test Project
 */
using System;
using System.Reflection;
using NUnitLite;

namespace Smart_Accounting.Domain.NUnitTest {
    class Program {
        static int Main (string[] args) {
            var typeInfo = typeof (Program).GetTypeInfo ();
            return new AutoRun (typeInfo.Assembly).Execute (args);
        }
    }
}