using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Employee.Models {
    public class UpdatedEmployeeDto : EmployeDto {
        [Required]
        public uint id { get; set; }
    }
}