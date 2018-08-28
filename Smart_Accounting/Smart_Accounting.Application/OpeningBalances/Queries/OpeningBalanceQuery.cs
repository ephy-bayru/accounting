using System;
using System.Collections.Generic;
using Smart_Accounting.Application.OpeningBalances.Interfaces;
using Smart_Accounting.Domain.OpeningBalances;

namespace Smart_Accounting.Application.OpeningBalances.Queries {
    public class OpeningBalanceQuery : IOpeningBalancesQuery {
        public IEnumerable<OpeningBalance> GetByAccount (uint accountId) {
            throw new NotImplementedException ();
        }

        public OpeningBalance GetById (uint id) {
            throw new NotImplementedException ();
        }

        public IEnumerable<OpeningBalance> GetByPeriod (DateTime date) {
            throw new NotImplementedException ();
        }
    }
}