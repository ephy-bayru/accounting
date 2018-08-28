using System.Collections.Generic;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Interfaces {
    public interface ILedgersQuery {
        Ledger GetById (uint id);
        IEnumerable<Ledger> GetAll ();
    }
}