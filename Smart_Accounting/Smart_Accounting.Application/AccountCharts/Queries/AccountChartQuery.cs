/*
 * @CreateTime: Oct 10, 2018 11:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 11:54 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Queries {
    public class AccountChartQuery : IAccountChartQueries {

        private IAccountingDatabaseService _database;
        public AccountChartQuery (IAccountingDatabaseService database) {
            _database = database;

        }

        public IEnumerable<AccountChart> GetAllAccounts (string type = "ALL") {
            if (type == "ALL") {
                return _database.AccountChart
                    .Select (account => new AccountChart () {
                        AccountCode = account.AccountCode,
                            AccountId = account.AccountId,
                            AccountType = account.AccountType,
                            OrganizationId = account.OrganizationId,
                            Name = account.Name,
                            DateAdded = account.DateAdded,
                            DateUpdated = account.DateUpdated,
                    }).ToList ();
            }
            return _database.AccountChart.Where (account => account.AccountType == type.ToUpper ());
        }
        public AccountChart GetAccountById (string accountId) {

            return _database.AccountChart
                .Select (account => new AccountChart () {
                    AccountCode = account.AccountCode,
                        AccountId = account.AccountId,
                        AccountType = account.AccountType,
                        OrganizationId = account.OrganizationId,
                        Name = account.Name,
                        DateAdded = account.DateAdded,
                        DateUpdated = account.DateUpdated,
                }).FirstOrDefault (account => account.AccountId == accountId);

        }

        public IEnumerable<AccountChart> GetAccountByType (string type) {
            return _database.AccountChart
                .Where (account => account.AccountType == type)
                .Select (account => new AccountChart () {
                    AccountCode = account.AccountCode,
                        AccountId = account.AccountId,
                        AccountType = account.AccountType,
                        OrganizationId = account.OrganizationId,
                        Name = account.Name,
                        DateAdded = account.DateAdded,
                        DateUpdated = account.DateUpdated,
                }).ToList ();
        }

        public IEnumerable<AccountChart> GetAllOrganizationAccount (uint organizationId) {
            return _database.AccountChart
                .Where (account => account.OrganizationId == organizationId)
                .Select (account => new AccountChart () {
                    AccountCode = account.AccountCode,
                        AccountId = account.AccountId,
                        AccountType = account.AccountType,
                        OrganizationId = account.OrganizationId,
                        Name = account.Name,
                        DateAdded = account.DateAdded,
                        DateUpdated = account.DateUpdated,
                }).ToList ();
        }
    }
}