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
            Customer = new HashSet<Customer> ();
            Employees = new HashSet<Employees> ();
            InverseSubAccountCodeNavigation = new HashSet<AccountChart> ();
            Jornal = new HashSet<Jornal> ();
            OpeningBalance = new HashSet<OpeningBalance> ();
            Suppliers = new HashSet<Suppliers> ();
            Tax = new HashSet<Tax> ();
        }

        public string AccountCode { get; set; }
        public string SubAccountCode { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public uint AccountId { get; set; }
        public uint OrganizationId { get; set; }
        public string AccountType { get; set; }

        public Organization Organization { get; set; }
        public AccountChart SubAccountCodeNavigation { get; set; }
        public ICollection<BankAccounts> BankAccounts { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<AccountChart> InverseSubAccountCodeNavigation { get; set; }
        public ICollection<Jornal> Jornal { get; set; }
        public ICollection<OpeningBalance> OpeningBalance { get; set; }
        public ICollection<Suppliers> Suppliers { get; set; }
        public ICollection<Tax> Tax { get; set; }
    }

}