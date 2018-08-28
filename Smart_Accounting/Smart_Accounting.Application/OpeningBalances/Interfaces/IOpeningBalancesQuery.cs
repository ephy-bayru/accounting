using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.OpeningBalances;

namespace Smart_Accounting.Application.OpeningBalances.Interfaces {
    public interface IOpeningBalancesQuery {
        OpeningBalance GetById (uint id);

        IEnumerable<OpeningBalance> GetByAccount (uint accountId);

        IEnumerable<OpeningBalance> GetByPeriod (DateTime date);
    }
}