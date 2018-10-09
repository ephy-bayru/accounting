using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain.Supplier
{
    public partial class SupplierAccount
    {
          public uint Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public uint SupplierId { get; set; }

        public Suppliers Supplier { get; set; }
    }
}
