using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Employee.Models {
    public abstract class EmployeDto {
        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set; }
        public string Email { get; set; }

        [Required]
        public string Phone_No { get; set; }

        [Required]
        public string Gender { get; set; }
        public string Account_Id { get; set; }
        public string Password { get; set; }
        public DateTime Birth_Date { get; set; }

    }
}