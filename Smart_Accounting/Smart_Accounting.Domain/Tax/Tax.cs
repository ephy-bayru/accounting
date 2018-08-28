using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class Tax
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public uint AccountId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}
