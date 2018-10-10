using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Supplier.Models.Accounts;

namespace Smart_Accounting.Application.Supplier.Models
{
    public class UpdateSupplierModel : SupplierDto
    {
        public uint id { get; set; }
<<<<<<< HEAD

        public IEnumerable<UpdatedSupplierAccountDto> BankAccounts {get; set;}
=======
        public IEnumerable<UpdatedSupplierAccountDto> Accounts {get; set;}
>>>>>>> dc5644a30638be867890f8569ac67aeef5f58e13
        = new List<UpdatedSupplierAccountDto>();
    }
}