using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartCommandsFactory {
        AccountType NewAccountType (NewAccountModel newType);
        AccountChart UpdatedAccountType (NewAccountModel newModel);

    }
}