using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.Ledgers;
using Smart_Accounting.Domain.OpeningBalances;

namespace Smart_Accounting.Domain.CalendarPeriods {
    public class CalendarPeriod {
        public CalendarPeriod () {
            Ledger = new HashSet<Ledger> ();
            OpeningBalance = new HashSet<OpeningBalance> ();
        }

        public uint PeriodId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public sbyte Active { get; set; }

        public ICollection<Ledger> Ledger { get; set; }
        public ICollection<OpeningBalance> OpeningBalance { get; set; }
    }
}