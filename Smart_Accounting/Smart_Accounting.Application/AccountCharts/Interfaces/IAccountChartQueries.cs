using System.Collections.Generic;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.AccountCharts.AccountTypes;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartQueries {
        AccountChart GetById (uint accountId);
        IEnumerable<AccountChart> GetAll ();
        IEnumerable<AccountType> GetAllAccountTypes ();
    }
}