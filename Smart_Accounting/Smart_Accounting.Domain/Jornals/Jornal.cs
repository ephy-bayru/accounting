using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.Currencies;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Domain.Jornals {
    public  class Jornal {
        public uint JornalId { get; set; }
        public double Credit { get; set; }
        public string AccountId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Reconcied { get; set; }
        public DateTime? ReconcieldOn { get; set; }
        public double Debit { get; set; }
        public uint CurrencyCode { get; set; }
        public uint Reference { get; set; }

        public AccountChart Account { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
        public Ledger ReferenceNavigation { get; set; }
    }
}