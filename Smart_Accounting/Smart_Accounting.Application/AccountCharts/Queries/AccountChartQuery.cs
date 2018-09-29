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

        public IEnumerable<AccountChart> GetAll () {
            return _database.AccountChart.ToList ();
        }
        public AccountChart GetById (uint accountId) {

            return _database.AccountChart.Find (accountId);

        }
    }
}