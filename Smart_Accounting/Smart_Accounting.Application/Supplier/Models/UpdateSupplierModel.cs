using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Supplier.Models.Accounts;

namespace Smart_Accounting.Application.Supplier.Models
{
    public class UpdateSupplierModel : SupplierDto
    {
        public uint id { get; set; }

        public IEnumerable<UpdatedSupplierAccountDto> Accounts {get; set;}
        = new List<UpdatedSupplierAccountDto>();
    }
}