using System.Collections.Generic;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Factories {
    public class EmployeeFactory : IEmployeeFactory {
        public List<EmployeeViewModel> createEmployeeView (IEnumerable<Employees> employee) {
            
            List<EmployeeViewModel> employeeViews = new List<EmployeeViewModel> ();
            
            foreach (var item in employee) {
                EmployeeViewModel view = new EmployeeViewModel () {
                    id = item.Id,
                        First_Name = item.FirstName,
                        Last_Name = item.LastName,
                        Email = item.Email,
                        Phone_No = item.Phone_No,
                        Gender = item.Gender,
                        Birth_Date = item.BirthDate,
                        Date_Created = item.DateCreated,
                        Date_Updated = item.DateUpdated
                };
                employeeViews.Add (view);
            
            }

            return employeeViews;

        }
    }
}