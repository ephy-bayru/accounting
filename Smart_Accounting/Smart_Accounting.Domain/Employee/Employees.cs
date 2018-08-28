using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class Employees
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint AccountId { get; set; }
        public double CreditLimit { get; set; }
        public DateTime? DateAdded { get; set; }
        public string DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}
