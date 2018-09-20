using System;

namespace Smart_Accounting.Application.Employee.Models {
     public class EmployeeViewModel{
        public string First_Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string gender { get; set; }
        public string Account_Id { get; set; }
        public DateTime? Birth_Date { get; set; }

     }
}