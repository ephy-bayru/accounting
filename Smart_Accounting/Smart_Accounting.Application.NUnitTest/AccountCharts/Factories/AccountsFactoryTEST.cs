/*
 * @CreateTime: Nov 7, 2018 10:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 7, 2018 2:25 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.AccountCharts.Factories;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.NUnitTest.AccountCharts.Factories {

    [Author ("Mikael  Araya", "Mikaelaraya12@gmail.com")]
    [TestFixture]
    public class AccountsFactoryTEST {

        private NewAccountModel newAccountModel;
        private AccountChartFactory accountChartFactory;
        private UpdatedAccountModel updatedAccountModel;
        private AccountChart accounts;
        private AccountChart updatedAccounts;
        private Mock<ICalendarPeriodQueries> MockICalendarPeriodQuery;

        [SetUp]
        public void Init () {
            newAccountModel = new NewAccountModel () {
                AccountCode = "444",
                AccountId = "555",
                AccountType = "ASSETS",
                Active = 1,
                Name = "First Account",
                OpeningBalance = 100,
                OrganizationId = 1,
                GlType = "Purchase",
                IsPosting = 0,
                IsReconcilation = 0,
            };

            updatedAccountModel = new UpdatedAccountModel () {
                AccountCode = "333",
                AccountId = "222",
                AccountType = "ASSETS",
                Active = 1,
                Name = "Second Account",
                OrganizationId = 1,
                GlType = "Purchase",
                IsPosting = 0,
                IsReconcilation = 0,
            };

            accounts = new AccountChart () {
                AccountCode = "444",
                AccountId = "555",
                AccountType = "ASSETS",
                Active = 1,
                Name = "First Account",
                OrganizationId = 1,
                GlType = "Purchase",
                DirectPosting = 0,
                IsReconcilation = 0,
            };

            updatedAccounts = new AccountChart () {
                AccountCode = "333",
                AccountId = "222",
                Name = "Second Account",
                Active = 1,
                AccountType = "ASSETS",
                OrganizationId = 1,
                GlType = "Purchase",
                DirectPosting = 0,
                IsReconcilation = 0,
            };

            MockICalendarPeriodQuery = new Mock<ICalendarPeriodQueries> ();
            MockICalendarPeriodQuery.Setup (p => p.getActivePeriod ())
                .Returns (new CalendarPeriod () {
                    Id = 1,
                        Start = new DateTime (2018, 08, 10),
                        End = new DateTime (2018, 10, 10),
                        Active = 1,
                        Closed = 0

                });

        }

        [Test]
        public void CreateAccountValidParameter_TEST () {
            accountChartFactory = new AccountChartFactory (MockICalendarPeriodQuery.Object);

            var result = accountChartFactory.NewAccount (newAccountModel);

            result.Should ().NotBeNull ();
            result.OpeningBalance.Select (o => new { o.Period }).Should ().Equal (new CalendarPeriod () {
                Id = 1,
                    Start = new DateTime (2018, 08, 10),
                    End = new DateTime (2018, 10, 10),
                    Active = 1,
                    Closed = 0

            });

        }

        [Test]
        public void UpdateAccountValidParameter_TEST () {

        
        }

    }
}