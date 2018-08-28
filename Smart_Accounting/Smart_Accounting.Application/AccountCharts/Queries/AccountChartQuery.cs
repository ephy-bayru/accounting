using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.AccountCharts.Queries
{
    public class AccountChartQuery : IAccountChartQueries
    {
        public IEnumerable<AccountChart> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public AccountChart GetById(uint accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}