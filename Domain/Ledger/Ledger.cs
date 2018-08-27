using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class Ledger
    {
        public Ledger()
        {
            Jornal = new HashSet<Jornal>();
        }

        public uint Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint PeriodId { get; set; }
        public string Discription { get; set; }

        public CalendarPeriod Period { get; set; }
        public ICollection<Jornal> Jornal { get; set; }
    }
}
