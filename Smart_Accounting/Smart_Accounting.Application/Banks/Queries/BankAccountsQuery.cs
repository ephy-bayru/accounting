using System.Collections.Generic;
using Smart_Accounting.Application.Banks.Interfaces;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.Banks.Queries {
    public class BankAccountsQuery : IBankAccountsQuery {
        public IEnumerable<BankAccounts> GetAll () {
            throw new System.NotImplementedException ();
        }

        public BankAccounts GetById (uint accountId) {
            throw new System.NotImplementedException ();
        }
    }
}