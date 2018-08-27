using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class Jornal
    {
        public uint JornalId { get; set; }
        public double Credit { get; set; }
        public uint AccountId { get; set; }
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
