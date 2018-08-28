using System.Collections.Generic;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.Banks.Interfaces {
    public interface IBankAccountsQuery {
        BankAccounts GetById (uint accountId);

        IEnumerable<BankAccounts> GetAll ();
    }
}