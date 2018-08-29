using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Application.AccountCharts.Queries {
    public class AccountChartQuery : IAccountChartQueries {

        private IAccountingDatabaseService _database;
        public AccountChartQuery(IAccountingDatabaseService database) {
            _database = database;
            
        }

        public IEnumerable<AccountChart> GetAll()
        {
            //TODO Define Functionality that will get all the accounts
            throw new System.NotImplementedException();
        }

        public IEnumerable<AccountType> GetAllAccountTypes()
        {
            
            return _database.AccountType.ToList();
        }

        public AccountChart GetById(uint accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}