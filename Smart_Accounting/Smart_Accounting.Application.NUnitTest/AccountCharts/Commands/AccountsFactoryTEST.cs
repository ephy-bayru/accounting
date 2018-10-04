using System.Collections.Generic;
using NUnit.Framework;
using Smart_Accounting.Application.AccountCharts.Factories;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;

namespace Smart_Accounting.Application.NUnitTest.AccountCharts.Commands {

    [Author ("Mikael  Araya", "Mikaelaraya12@gmail.com")]
    [TestFixture]
    public class AccountsFactoryTEST {

        private IEnumerable<NewAccountModel> newAccountModel;
        private IEnumerable<AccountChartFactory> accountChartFactory;
        private IEnumerable<UpdatedAccountModel> updatedAccountModel;

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

            accountChartFactory = new List<AccountChartFactory> ();

        }

        [Test]
        public void CreateAccountValidParameter_TEST() {
            
        }


    }
}