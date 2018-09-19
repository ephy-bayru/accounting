using System;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Employe
{
    public class Employees
    {
        public long Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountChart Account_Id { get; set; }
        public string Gender {get; set; }
        public DateTime? Birth_Date { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated {get; set; }
    }
}
