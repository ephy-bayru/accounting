using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Supplier.Models
{
    public abstract class SupplierDto
    {
        public string FullName { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }

    }
}