/*
 * @CreateTime: Oct 9, 2018 9:38 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 9:42 AM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands.Factories {
    public class EmployeeCommandsFactory : IEmployeeCommandsFactory {
        public Employees NewEmployee (NewEmployeeModel newEmp) {
            var employee = new Employees ();

            employee.FirstName = newEmp.First_Name;
            employee.LastName = newEmp.Last_Name;
            employee.Email = newEmp.Email;
            employee.Phone_No = newEmp.Phone_No;
            employee.Gender = newEmp.Gender;
            employee.Password = newEmp.Password;
            employee.BirthDate = newEmp.Birth_Date;

            return employee;
        }

        // throw new System.NotImplementedException();
        public EmployeeViewModel EmployeeView (Employees employee) {
            var employees = new EmployeeViewModel ();

            employees.id = employee.Id;
            employees.First_Name = employee.FirstName;
            employees.Last_Name = employee.FirstName;
            employees.Email = employees.Email;
            employees.Phone_No = employee.Phone_No;
            employees.Birth_Date = employee.BirthDate;
            employees.Gender = employee.Gender;
            employees.Date_Created = employee.DateCreated;
            employees.Date_Updated = employee.DateUpdated;

            return employees;

        }

        public Employees UpdatesEmployee (Employees currentEmployee, UpdatedEmployeeDto updateEmployee) {
            currentEmployee.FirstName = updateEmployee.First_Name;
            currentEmployee.LastName = updateEmployee.Last_Name;
            currentEmployee.Email = updateEmployee.Email;
            currentEmployee.Phone_No = updateEmployee.Phone_No;
            currentEmployee.BirthDate = updateEmployee.Birth_Date;
            currentEmployee.Gender = updateEmployee.Gender;
            currentEmployee.Password = updateEmployee.Password;

            return currentEmployee;
        }
    }
}