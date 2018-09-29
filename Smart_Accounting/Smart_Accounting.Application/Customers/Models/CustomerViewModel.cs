using System;

namespace Smart_Accounting.Application.Customers.Models
{
    public class CustomerViewModel
    {
        public uint id { get; set; }
        public string FullName { get; set; }
        public uint? AccountId { get; set; }
        public Int32 AccountNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string PostalCode { get; set; }
        
    }
}