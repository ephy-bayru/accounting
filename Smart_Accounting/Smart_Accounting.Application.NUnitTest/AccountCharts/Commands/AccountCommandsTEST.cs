using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.AccountCharts.Command;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.NUnitTest.AccountCharts.Commands {
    [TestFixture]
    [Author ("Mikael Araya", "Mikaelaraya12@gmail.com")]
    public class AccountCommandsTEST {

        private IEnumerable<NewAccountModel> newAccountModel;
        private IEnumerable<UpdatedAccountModel> updatedAccountModel;
        private Mock<AccountChartCommands> accountCommands;
        private Mock<IAccountingDatabaseService> MockIAccountingDatabaseService;
        private IEnumerable<AccountChart> accounts;
        private IEnumerable<AccountChart> updatedAccounts;

        [SetUp]
        public void Init () {
            newAccountModel = new List<NewAccountModel> () {
                new NewAccountModel () {
                AccountCode = "444",
                AccountId = "555",
                AccountType = "ASSETS",
                Active = 1,
                Name = "First Account",
                OpeningBalance = 100,
                OrganizationId = 1
                },
                new NewAccountModel () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OpeningBalance = 100,
                OrganizationId = 1
                }
            };
            updatedAccountModel = new List<UpdatedAccountModel> () {
                new UpdatedAccountModel () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OrganizationId = 1
                },
                new UpdatedAccountModel () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OrganizationId = 1
                }
            };

            accounts = new List<AccountChart> () {
                new AccountChart () {
                AccountCode = "ACC-001",
                Name = "First Account",
                Active = 1,
                AccountType = "ASSET",
                AccountId = "ACC-003",
                OrganizationId = 11
                },
                new AccountChart () {
                AccountCode = "ACC-002",
                Name = "Second Account",
                Active = 1,
                AccountType = "LIABILITY",
                AccountId = "ACC-003",
                OrganizationId = 11
                }
            };


            updatedAccounts = new List<AccountChart> () {
                new AccountChart () {
                AccountCode = "ACC-005",
                Name = "Third Account",
                Active = 1,
                AccountType = "ASSET",
                AccountId = "ACC-007",
                OrganizationId = 11
                },
                new AccountChart () {
                AccountCode = "ACC-006",
                Name = "Fourth Account",
                Active = 1,
                AccountType = "LIABILITY",
                AccountId = "ACC-003",
                OrganizationId = 11
                }
            };

            accountCommands = new Mock<AccountChartCommands> ();
            MockIAccountingDatabaseService = new Mock<IAccountingDatabaseService> ();
            MockIAccountingDatabaseService.Setup (database => database.AccountChart.AddRange (accounts));
            MockIAccountingDatabaseService.Setup (database => database.AccountChart.UpdateRange (updatedAccounts));
            MockIAccountingDatabaseService.Setup (database => database.AccountChart.Remove (new AccountChart () {
                AccountCode = "ACC-006",
                Name = "Fourth Account",
                Active = 1,
                AccountType = "LIABILITY",
                AccountId = "ACC-003",
                OrganizationId = 11
                }));
            MockIAccountingDatabaseService.Setup (database => database.Save ());

        }

        [Test]
        public void AccountCommand_Create_VALID_Data_TEST () {

            AccountChartCommands account_command = new AccountChartCommands (MockIAccountingDatabaseService.Object);

            var result = account_command.createAccount (accounts);

            Assert.That (result.Equals (accounts));

        }

        [Test]
        public void AccountCommand_UpdateAccount_VALID_DATA_TEST () {
            AccountChartCommands account_command = new AccountChartCommands (MockIAccountingDatabaseService.Object);

            var result = account_command.updateAccount (updatedAccounts);

            Assert.That (result.Equals (true));
        }

        [Test]
        public void AccountCommand_DeleteAccount_VALID_DATA_TEST () {
            AccountChartCommands account_command = new AccountChartCommands (MockIAccountingDatabaseService.Object);

            var result = account_command.deleteAccount (new AccountChart () {
                AccountCode = "ACC-006",
                Name = "Fourth Account",
                Active = 1,
                AccountType = "LIABILITY",
                AccountId = "ACC-003",
                OrganizationId = 11
                });

            Assert.That (result.Equals (true));
        }

    }
}