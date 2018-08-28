using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Queries {
    public class AccountChartQuery : IAccountChartQueries {
        IEnumerable<AccountChart> IAccountChartQueries.GetAll () {
            throw new System.NotImplementedException ();
        }

        AccountChart IAccountChartQueries.GetById (uint accountId) {
            throw new System.NotImplementedException ();
        }
    }
}