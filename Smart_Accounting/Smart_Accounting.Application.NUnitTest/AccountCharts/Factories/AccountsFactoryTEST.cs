using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Smart_Accounting.Application.AccountCharts.Factories;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.NUnitTest.AccountCharts.Factories {

    [Author ("Mikael  Araya", "Mikaelaraya12@gmail.com")]
    [TestFixture]
    public class AccountsFactoryTEST {

        private IEnumerable<NewAccountModel> newAccountModel;
        private IEnumerable<AccountChartFactory> accountChartFactory;
        private IEnumerable<UpdatedAccountModel> updatedAccountModel;
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
                AccountCode = "444",
                AccountId = "555",
                AccountType = "ASSETS",
                Active = 1,
                Name = "First Account",
                OrganizationId = 1
                },
                new AccountChart () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OrganizationId = 1
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

            accountChartFactory = new List<AccountChartFactory> ();

        }

        [Test]
        public void CreateAccountValidParameter_TEST () {

                //TODO : Implement createAccountValidParameter_TEST in account factory

        }

    }
}