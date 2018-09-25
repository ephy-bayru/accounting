using Smart_Accounting.Application.AccountCharts.Models;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartCommands {
        void createAccount (NewAccountModel newAccount);
        void creatAccountType (NewAccountModel newType);

        void updateAccount(UpdatedAccountModel updatedAccount);
        void delete ();
    }
}