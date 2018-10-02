using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Taxes {
    public partial class Tax {
        public uint Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string AccountId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public AccountChart Account { get; set; }
    }
}