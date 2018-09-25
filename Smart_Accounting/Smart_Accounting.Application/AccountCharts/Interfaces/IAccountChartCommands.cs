using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Models;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartCommands {
        void createAccount (IEnumerable<NewAccountModel> newAccount);
        void updateAccount(IEnumerable<UpdatedAccountModel> updatedAccount);
        void delete ();
    }
}