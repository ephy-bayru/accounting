
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Application.AccountCharts.Commands
{
    public class AccountChartCommandsFactory : IAccountChartCommandsFactory
    {
        public AccountType NewAccountType(NewAccountTypeModel newType)
        {
            var type = new AccountType();

            type.Name = newType.Name;

            return type;
        }
    }
}