using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Supplier
{
    public partial class Suppliers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string AccountId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}