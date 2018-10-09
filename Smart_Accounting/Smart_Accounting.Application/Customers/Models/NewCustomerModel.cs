using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Customers.Models.AccountModels;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Models {
    public class NewCustomerModel : CustomerDto {
        public IEnumerable<NewCustomerAccountDto> BankAccounts { get; set; }

    }
}