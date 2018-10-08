using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Customers {
    public partial class Customer {
        public Customer()
        {
            CustomerAccount = new HashSet<CustomerAccount>();
        }

        public uint Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
<<<<<<< HEAD
        public string Account_Number { get; set; }
=======
>>>>>>> f886edf8d36efeea40cf0292fdc5a8fff5227560
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public ICollection<CustomerAccount> CustomerAccount { get; set; }
    }
}