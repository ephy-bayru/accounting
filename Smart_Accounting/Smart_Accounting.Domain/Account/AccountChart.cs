using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class AccountChart
    {
                public AccountChart()
        {
            BankAccounts = new HashSet<BankAccounts>();
            Customer = new HashSet<Customer>();
            Employees = new HashSet<Employees>();
            InverseSubAccountCodeNavigation = new HashSet<AccountChart>();
            Jornal = new HashSet<Jornal>();
            OpeningBalance = new HashSet<OpeningBalance>();
            Suppliers = new HashSet<Suppliers>();
            Tax = new HashSet<Tax>();
        }

        public string AccountCode { get; set; }
        public string SubAccountCode { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public uint AccountId { get; set; }
        public uint AccountType { get; set; }
        public int AccountCategoryAccCatId { get; set; }
        public uint OrganizationId { get; set; }

        public AccountType AccountTypeNavigation { get; set; }
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