using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;

using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Command {
    public class AccountChartCommands : IAccountChartCommands {

        private readonly IAccountingDatabaseService _database;

        public AccountChartCommands (IAccountingDatabaseService database ) {
            _database = database;
        }

        public bool deleteAccount (AccountChart account) {
            _database.AccountChart.Remove(account);
            return true;
        }

        public IEnumerable<AccountChart> createAccount (IEnumerable<AccountChart> newAccount) {
            _database.AccountChart.AddRange (newAccount);
            _database.Save ();
            return newAccount;

        }

        public bool updateAccount (AccountChart updatedAccount) {
            _database.AccountChart.Update (updatedAccount);
            _database.Save ();
            return true;
        }
    }
}