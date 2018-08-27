using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class Suppliers
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public sbyte TaxIncluded { get; set; }
        public int? CreditLimit { get; set; }
        public string BankAccount { get; set; }
        public sbyte Active { get; set; }
        public uint AccountId { get; set; }

        public AccountChart Account { get; set; }
    }
}
