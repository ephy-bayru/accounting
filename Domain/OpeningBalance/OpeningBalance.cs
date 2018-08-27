using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class OpeningBalance
    {
        public uint Id { get; set; }
        public uint AccountId { get; set; }
        public uint PeriodId { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AccountChart Account { get; set; }
        public CalendarPeriod Period { get; set; }
    }
}
