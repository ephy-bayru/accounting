/*
 * @CreateTime: Sep 4, 2018 12:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 12:23 PM
 * @Description: Account Type Database Entity Model Test 
 */
using NUnit.Framework;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Domain.NUnitTest.Accounts {
    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    [TestFixture]
    public class AccountTypeTest {
        private AccountType accountType;

        [SetUp] //Initialize Basic AccountType Data
        public void Init () {
            accountType = new AccountType ();

            accountType.AccTypeId = 1;
            accountType.Name = "Asset";
            accountType.Active = "1";
        }

        [Test]
        public void AccountTypeInitializationTEST () {

            Assert.That (accountType.AccTypeId, Is.EqualTo (1));
            Assert.That (accountType.Name, Is.EqualTo ("Asset"));
            Assert.That (accountType.Active, Is.EqualTo ("1"));

        }

    }
}