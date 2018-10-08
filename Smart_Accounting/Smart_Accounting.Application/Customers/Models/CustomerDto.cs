using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Customers.Models
{
    public abstract class CustomerDto
    {
        public string FullName { get; set; }
        public string Account_Number { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }

    }
}