/*
 * @CreateTime: Oct 9, 2018 10:24 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 10:25 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Customers.Models
{
    public abstract class CustomerDto
    {
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone_No { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNo { get; set; }
        public string PostalCode { get; set; }
        public float CreditLimit {get; set; }
        public float Balance {get; set; }
        public sbyte Active { get; set; }
        public sbyte Blocked { get; set; }

    }
}