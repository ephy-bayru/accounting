using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Customers.Models.AccountModels;

namespace Smart_Accounting.Application.Customers.Models {
    public class NewCustomerModel : CustomerDto {
        public List<NewCustomerAccountDto> BankAccounts { get; set; } = new List<NewCustomerAccountDto>();

    }
}