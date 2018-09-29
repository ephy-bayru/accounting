using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Customers.Models
{
    public class UpdateCustomerModel : CustomerDto
    {
        public uint id { get; set; }
    }
}