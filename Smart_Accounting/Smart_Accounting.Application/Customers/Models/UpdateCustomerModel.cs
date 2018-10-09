using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Customers.Models.AccountModels;

namespace Smart_Accounting.Application.Customers.Models {
    public class UpdateCustomerModel : CustomerDto {
        [Required]
        public uint id { get; set; }
        public IEnumerable<UpdatedCustomerAccountDto> BankAccounts { get; set; } = new List<UpdatedCustomerAccountDto> ();
    }
}