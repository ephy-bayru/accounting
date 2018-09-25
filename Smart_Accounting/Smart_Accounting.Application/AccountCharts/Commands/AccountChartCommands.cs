using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Command {
    public class AccountChartCommands : IAccountChartCommands {

        private readonly IAccountingDatabaseService _database;

        public AccountChartCommands (IAccountingDatabaseService database) {
            _database = database;
        }

        public bool delete () {
            //TODO Define account deletion Functionality

            throw new System.NotImplementedException ();
        }

        public IEnumerable<AccountChart> createAccount (IEnumerable<AccountChart> newAccount) {
            _database.AccountChart.AddRange (newAccount);
            _database.Save();
            return newAccount;

        }

        public bool updateAccount(IEnumerable<AccountChart> updatedAccount)
        {
            throw new System.NotImplementedException();
        }
    }
}