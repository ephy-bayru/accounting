/*
 * @CreateTime: Nov 2, 2018 3:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:04 PM
 * @Description: Modify Here, Please 
 */
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

        public uint Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public sbyte Active { get; set; }
        public sbyte Closed { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? IsBegining { get; set; }

        public ICollection<Ledger> Ledger { get; set; }
        public ICollection<OpeningBalance> OpeningBalance { get; set; }
    }
}