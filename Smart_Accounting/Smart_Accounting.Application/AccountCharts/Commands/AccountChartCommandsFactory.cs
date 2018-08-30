
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Application.AccountCharts.Commands
{
    public class AccountChartCommandsFactory : IAccountChartCommandsFactory
    {
        public AccountType NewAccountType(NewAccountTypeModel newType)
        {
            throw new System.NotImplementedException();
        }

        public AccountChart UpdatedAccountType(NewAccountModel newModel)
        {
            throw new System.NotImplementedException();
        }
    }
}