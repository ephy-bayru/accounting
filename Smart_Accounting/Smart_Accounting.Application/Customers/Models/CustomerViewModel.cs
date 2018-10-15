using System;

namespace Smart_Accounting.Application.Customers.Models
{
    public class CustomerViewModel
    {
        public uint id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string PostalCode { get; set; }
        public string CustomerAccount {get; set; }
        
    }
}