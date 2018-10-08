using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.BankAccount;
using Smart_Accounting.Domain.Customers;
using Smart_Accounting.Domain.Employe;
using Smart_Accounting.Domain.Jornals;
using Smart_Accounting.Domain.OpeningBalances;
using Smart_Accounting.Domain.Oranizations;
using Smart_Accounting.Domain.Supplier;
using Smart_Accounting.Domain.Taxes;

namespace Smart_Accounting.Domain.AccountCharts {
    public class AccountChart {
        public AccountChart () {
            BankAccounts = new HashSet<BankAccounts> ();
            Jornal = new HashSet<Jornal> ();
            OpeningBalance = new List<OpeningBalance> ();
            Tax = new HashSet<Tax> ();
        }

        public string AccountCode { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public string AccountType { get; set; }
        public string AccountId { get; set; }
        public uint OrganizationId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Organization Organization { get; set; }
        public ICollection<BankAccounts> BankAccounts { get; set; }
        public ICollection<Jornal> Jornal { get; set; }
        public List<OpeningBalance> OpeningBalance { get; set; } 
        public ICollection<Tax> Tax { get; set; }
    }

}