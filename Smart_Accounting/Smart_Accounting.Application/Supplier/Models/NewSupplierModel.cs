using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Supplier.Models.Accounts;

namespace Smart_Accounting.Application.Supplier.Models {
    public class NewSupplierModel : SupplierDto {
        public IEnumerable<NewSupplierAccountDto> BankAccounts { get; set; } = new List<NewSupplierAccountDto> ();
    }
}