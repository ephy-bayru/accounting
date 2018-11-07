/*
 * @CreateTime: Nov 2, 2018 3:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 5:14 PM
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
            BankAccounts = new List<BankAccounts>();
            Jornal  = new List<Jornal>();
            OpeningBalance =  new List<OpeningBalance>();
            Tax = new List<Tax> ();
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
        public sbyte? Closed { get; set; }
        public sbyte? IsReconcilation { get; set; }
        public sbyte? DirectPosting { get; set; }

        public Organization Organization { get; set; }
        public List<BankAccounts> BankAccounts { get; set; }
        public List<Jornal> Jornal { get; set; }
        public List<OpeningBalance> OpeningBalance { get; set; } 
        public List<Tax> Tax { get; set; }
    }

}