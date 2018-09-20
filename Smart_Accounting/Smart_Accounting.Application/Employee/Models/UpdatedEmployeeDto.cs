using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Employee.Models {
    public class UpdatedEmployeeDto : EmployeDto {
        [Required]
        public long id { get; set; }
    }
}