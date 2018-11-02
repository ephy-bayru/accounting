/*
 * @CreateTime: Nov 2, 2018 3:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:43 PM
 * @Description: Modify Here, Please 
 */
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
                        Phone_No = item.PhoneNo,
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