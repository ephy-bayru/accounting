using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain.Customers
{
    public partial class Customer
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint AccountId { get; set; }
        public float CreditLimit { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}
