using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain.Customers {
    public partial class CustomerAccount {
        public uint Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public uint CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}