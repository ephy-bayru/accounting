/*
 * @CreateTime: Oct 17, 2018 2:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 27, 2018 11:18 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.BankAccount;
using Smart_Accounting.Domain.OpeningBalances;
using Smart_Accounting.Domain.Oranizations;
using Smart_Accounting.Domain.Taxes;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class JornalEntryViewModel {

        public uint Id { get; set; }
        public string Account { get; set; }
        public string AccountId { get; set; }
        public double Amount { get; set; }
        public uint Reference { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool? Closed { get; set; }
        public bool? IsReconcilation { get; set; }
        public bool? DirectPositng { get; set; }
        public Organization Organization { get; set; }
        public ICollection<BankAccounts> BankAccounts { get; set; }
        public ICollection<Domain.Jornals.Jornal> Jornal { get; set; }
        public ICollection<OpeningBalance> OpeningBalance { get; set; }
        public ICollection<Tax> Tax { get; set; }
    }
}