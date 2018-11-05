/*
 * @CreateTime: Oct 10, 2018 11:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:20 PM
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
        private IQueryable<AccountChart> AccountChartQuariable () {
            return _database.AccountChart.Select (account => new AccountChart () {
                AccountCode = account.AccountCode,
                    AccountId = account.AccountId,
                    AccountType = account.AccountType,
                    Active = account.Active,
                    Closed = account.Closed,
                    Type = account.Type,
                    IsReconcilation = account.IsReconcilation,
                    DirectPositng = account.DirectPositng,
                    GlType = account.GlType,
                    OrganizationId = account.OrganizationId,
                    Name = account.Name,
                    DateAdded = account.DateAdded,
                    DateUpdated = account.DateUpdated,
                    OpeningBalance = account.OpeningBalance
            });

        }
        public IEnumerable<AccountChart> GetAllAccounts (string type = "ALL") {
            if (type == "ALL") {
                return AccountChartQuariable().ToList();
            }
            return AccountChartQuariable()
                                    .Where (account => account.AccountType == type.ToUpper ());
        }
        public AccountChart GetAccountById (string accountId) {

            return AccountChartQuariable()
                        .FirstOrDefault (account => account.AccountId == accountId);

        }

        public IEnumerable<AccountChart> GetAccountByType (string type) {
            return AccountChartQuariable()
                    .Where (account => account.AccountType == type)
                    .ToList ();
        }

        public IEnumerable<AccountChart> GetAllOrganizationAccount (uint organizationId) {
            return AccountChartQuariable()
                .Where (account => account.OrganizationId == organizationId)
                .ToList ();
        }
    }
}