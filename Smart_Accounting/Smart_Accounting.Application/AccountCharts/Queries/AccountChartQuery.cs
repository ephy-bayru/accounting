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
                return _database.AccountChart.ToList ();
            }
            return _database.AccountChart.Where (account => account.AccountType == type.ToUpper ());
        }
        public AccountChart GetAccountById (string accountId) {

            return _database.AccountChart.Find (accountId);

        }
    }
}