using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Domain.OpeningBalances {
    public partial class OpeningBalance {
        public uint Id { get; set; }
        public string AccountId { get; set; }
        public uint PeriodId { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AccountChart Account { get; set; }
        public CalendarPeriod Period { get; set; }
    }
}