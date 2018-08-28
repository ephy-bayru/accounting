using System.Collections.Generic;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartQueries {
        AccountChart GetById (uint accountId);
        IEnumerable<AccountChart> GetAll ();
    }
}