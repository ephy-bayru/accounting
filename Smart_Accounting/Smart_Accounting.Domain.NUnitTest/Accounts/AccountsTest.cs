/*
 * @CreateTime: Sep 3, 2018 12:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 12:23 PM
 * @Description: Account Chart Database Entity Model
 */
using NUnit.Framework;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Domain.NUnitTest.Account {

    [Author ("Mikael Araya", "Mikaelaraya12@gmail.com")]
    [TestFixture]
    public class AccountChartTest {

        public AccountChart account;

        [SetUp] //Initialize Basic Account Chart Data
        public void Init () {
            account = new AccountChart () {
                AccountId = 1,
                Active = 0,
                AccountCode = "2",
                Name = "Cash",
                SubAccountCode = "3",
                AccountTypeNavigation = new AccountType ()
            };

        }

        [Test]
        public void AccountChartInitializationTEST () {

            Assert.That (account.Name, Is.EqualTo ("Cash"));
            Assert.That (account.SubAccountCode, Is.EqualTo ("3"));
            Assert.That (account.AccountId, Is.EqualTo (1));
            Assert.That (account.Active, Is.EqualTo (0));
            Assert.That (account.AccountCode, Is.EqualTo ("2"));

        }

        // Test if Account Type is Initialized Correctly
        [Test]
        public void AccountChartAccountTypeInitializationTest () {

            AccountType type = new AccountType ();

            type.AccTypeId = 1;
            type.Name = "Asset";
            type.Active = "1";

            account.AccountTypeNavigation = type;

            Assert.That (account.AccountTypeNavigation.Name, Is.EqualTo ("Asset"));
            Assert.That (account.AccountTypeNavigation.AccTypeId, Is.EqualTo (1));
            Assert.That (account.AccountType, Is.EqualTo (0));
        }

    }
}