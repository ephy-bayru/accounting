using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.BankAccount {
    public partial class BankAccounts {
        public uint BankId { get; set; }
        public string Name { get; set; }
        public string BankAccountCode { get; set; }
        public string BankCreditAccount { get; set; }
        public string BankDebitAccount { get; set; }
        public uint AccountId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}