using System.Collections.Generic;
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Queries {
    public class LedgersQuery : ILedgersQuery {
        public IEnumerable<Ledger> GetAll () {
            throw new System.NotImplementedException ();
        }

        public Ledger GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}