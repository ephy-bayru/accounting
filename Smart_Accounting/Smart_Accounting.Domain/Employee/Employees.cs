using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Employee {
    public partial class Employees {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint AccountId { get; set; }
        public double CreditLimit { get; set; }
        public DateTime? DateAdded { get; set; }
        public string DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}