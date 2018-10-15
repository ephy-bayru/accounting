using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartCommands {
        IEnumerable<AccountChart> createAccount (IEnumerable<AccountChart> newAccount);
        bool updateAccount(AccountChart updatedAccount);
        bool deleteAccount (AccountChart account);
    }
}