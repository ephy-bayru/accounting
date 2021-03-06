using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Supplier.Models
{
    public abstract class SupplierDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }
        public float Balance {get; set; }
        public sbyte Active { get; set; }

    }
}