/*
 * @CreateTime: Nov 2, 2018 3:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:31 PM
 * @Description: Modify Here, Please 
 */
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
            OpeningBalance = new HashSet<OpeningBalance> ();
            Tax = new HashSet<Tax> ();
        }

        public string AccountCode { get; set; }
        public string Name { get; set; }
        public sbyte? Active { get; set; }
        public string AccountType {get; set;}
        public string AccountId { get; set; }
        public string GlType { get; set; }
        public string Type { get; set; }
        public uint OrganizationId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? Closed { get; set; }
        public sbyte? IsReconcilation { get; set; }
        public sbyte? DirectPositng { get; set; }

        public Organization Organization { get; set; }
        public ICollection<BankAccounts> BankAccounts { get; set; }
        public ICollection<Jornal> Jornal { get; set; }
        public ICollection<OpeningBalance> OpeningBalance { get; set; }
        public ICollection<Tax> Tax { get; set; }
    }

}