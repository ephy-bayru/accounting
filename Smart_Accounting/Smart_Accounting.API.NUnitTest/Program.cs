/*
 * @CreateTime: Sep 4, 2018 12:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 12:33 PM
 * @Description: Fininace System API Test Project
 */
using System;
using System.Reflection;
using NUnitLite;

namespace Smart_Accounting.API.NUnitTest {
    class Program {
        static int Main (string[] args) {
            var typeInfo = typeof (Program).GetTypeInfo ();
            return new AutoRun (typeInfo.Assembly).Execute (args);
        }
    }
}