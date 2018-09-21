using System;

namespace Smart_Accounting.Application.Employee.Models {
     public class EmployeeViewModel{
         public uint id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Gender { get; set; }
        public uint Account_Id { get; set; }
        public DateTime? Birth_Date { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }


     }
}