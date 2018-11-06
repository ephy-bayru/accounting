using System;

namespace Smart_Accounting.Application.Supplier.Models
{
    public class SupplierViewModel
    {
        public uint id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string PostalCode { get; set; }
        public float Balance { get; set; }
        public sbyte Active { get; set; }

        
    }
}