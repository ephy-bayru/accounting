using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Supplier {
    public partial class Suppliers {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public sbyte TaxIncluded { get; set; }
        public int? CreditLimit { get; set; }
        public string BankAccount { get; set; }
        public sbyte Active { get; set; }
        public string AccountId { get; set; }

        public AccountChart Account { get; set; }
    }
}