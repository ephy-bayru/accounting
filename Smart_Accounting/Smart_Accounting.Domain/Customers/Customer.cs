/*
 * @CreateTime: Nov 2, 2018 3:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:03 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Customers {
    public partial class Customer {
        public Customer () {
            CustomerAccount = new HashSet<CustomerAccount> ();
        }

        public uint Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? CreditLimit { get; set; }
        public float? Balance { get; set; }
        public sbyte? Active { get; set; }
        public sbyte? Blocked { get; set; }

        public ICollection<CustomerAccount> CustomerAccount { get; set; }
    }
}