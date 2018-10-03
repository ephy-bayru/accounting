using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Supplier.Models
{
    public class UpdateSupplierModel : SupplierDto
    {
        public uint id { get; set; }
    }
}