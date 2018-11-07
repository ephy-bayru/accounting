using System.Collections.Generic;
using Microsoft.Extensions.Logging;
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

        private NewAccountModel newAccountModel;
        private UpdatedAccountModel updatedAccountModel;
        private Mock<AccountChartCommands> accountCommands;
        private Mock<IAccountingDatabaseService> MockIAccountingDatabaseService;

        private Mock<ILogger<AccountChartCommands>> MockILogger;
        private AccountChart accounts;
        private AccountChart updatedAccounts;

        [SetUp]
        public void Init () {
            /*
            Mock Data that will be passed as an argument for when new account is created
             */
            newAccountModel = new NewAccountModel () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OpeningBalance = 100,
                OrganizationId = 1
            };
            /*
            Data to mock the data passed for an updated account
             */

            updatedAccountModel = new UpdatedAccountModel () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OrganizationId = 1
            };

            // mock data that will be used to mock account data in a domain object
            accounts = new AccountChart () {
                AccountCode = "ACC-002",
                Name = "Second Account",
                Active = 1,
                AccountType = "LIABILITY",
                AccountId = "ACC-003",
                OrganizationId = 11
                };
            
            // mock data that will be used to mock account data in a domain object

                updatedAccounts = new AccountChart () {
                AccountCode = "ACC-005",
                Name = "Third Account",
                Active = 1,
                AccountType = "ASSET",
                AccountId = "ACC-007",
                OrganizationId = 11
            };

            // create mock accountchartcommand logger 
            MockILogger = new Mock<ILogger<AccountChartCommands>> ();

            accountCommands = new Mock<AccountChartCommands> ();  // mock account chart command
            MockIAccountingDatabaseService = new Mock<IAccountingDatabaseService> (); // mock database repository

            // mock the repository operation of creating new account
            MockIAccountingDatabaseService.Setup (database => database.AccountChart.Add (accounts)); 
            // mock the repository operation of updating existing account
            MockIAccountingDatabaseService.Setup (database => database.AccountChart.Update (updatedAccounts));
            // mock the repository operation of deleting account
            MockIAccountingDatabaseService.Setup (database => database.AccountChart.Remove (accounts));
            // mock the repository save operation
            MockIAccountingDatabaseService.Setup (database => database.Save ());

        }

        /// <summary>
        /// Testing result of the create account when new account is created
        /// </summary>
        [Test]
        public void AccountCommand_Create_VALID_Data_TEST () {

            AccountChartCommands account_command = new AccountChartCommands (MockIAccountingDatabaseService.Object,
                MockILogger.Object);

            var result = account_command.createAccount (accounts);

            Assert.That (result.Equals (accounts));

        }

        /// <summary>
        ///  Test for when updating with valid data 
        /// </summary>

        [Test]
        public void AccountCommand_UpdateAccount_VALID_DATA_TEST () {
            AccountChartCommands account_command = new AccountChartCommands (MockIAccountingDatabaseService.Object,
            MockILogger.Object);

            var result = account_command.updateAccount (updatedAccounts);

            Assert.That (result.Equals (true));
        }

        /// <summary>
        /// Test for when deleting account with valid data
        /// </summary>
        [Test]
        public void AccountCommand_DeleteAccount_VALID_DATA_TEST () {
            AccountChartCommands account_command = new AccountChartCommands (MockIAccountingDatabaseService.Object,
            MockILogger.Object);

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