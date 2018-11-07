/*
 * @CreateTime: Oct 10, 2018 11:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:20 PM
 * @Description: Class used to make all the retriving operations
 * required for Account
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

        /// <summary>
        ///  returns IQuariable<AccountChart> to be used for further
        ///  processing by other functions
        /// </summary>
        /// <returns></returns>
        private IQueryable<AccountChart> AccountChartQuariable () {
            return _database.AccountChart.Select (account => new AccountChart () {
                AccountCode = account.AccountCode,
                    AccountId = account.AccountId,
                    AccountType = account.AccountType,
                    Active = account.Active,
                    Closed = account.Closed,
                    Type = account.Type,
                    IsReconcilation = account.IsReconcilation,
                    DirectPosting = account.DirectPosting,
                    GlType = account.GlType,
                    OrganizationId = account.OrganizationId,
                    Name = account.Name,
                    DateAdded = account.DateAdded,
                    DateUpdated = account.DateUpdated,
                    OpeningBalance = account.OpeningBalance
            });

        }
        /// <summary>
        ///  returns all accounts 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<AccountChart> GetAllAccounts (string type = "ALL") {
            if (type == "ALL") {
                return AccountChartQuariable ().ToList ();
            }
            return AccountChartQuariable ()
                .Where (account => account.AccountType == type.ToUpper ());
        }

        /// <summary>
        ///  return account of a given   Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountChart GetAccountById (string accountId) {

            return AccountChartQuariable ()
                .FirstOrDefault (account => account.AccountId == accountId);

        }

        /// <summary>
        /// Gets all accounts of a given type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<AccountChart> GetAccountByType (string type) {
            return AccountChartQuariable ()
                .Where (account => account.AccountType == type)
                .ToList ();
        }

        /// <summary>
        /// Gets all existing accounts registered under a given organization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public IEnumerable<AccountChart> GetAllOrganizationAccount (uint organizationId) {
            return AccountChartQuariable ()
                .Where (account => account.OrganizationId == organizationId)
                .ToList ();
        }
    }
}