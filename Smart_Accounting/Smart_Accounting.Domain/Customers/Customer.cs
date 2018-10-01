using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Customers
{
    public partial class Customer
    {
        public uint Id { get; set; }
        public string FullName { get; set; }
        public uint AccountId { get; set; }
        public Int32 AccountNumber { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public int PostalCode { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set;}
        public AccountChart Account { get; set; }
    }
}
