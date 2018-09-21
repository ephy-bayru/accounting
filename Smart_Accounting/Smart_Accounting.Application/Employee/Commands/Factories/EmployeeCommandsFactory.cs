using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands.Factories
{
    public class EmployeeCommandsFactory : IEmployeeCommandsFactory
    {
        public Employees NewEmployee(NewEmployeeModel newEmp)
        {
            var employee = new  Employees();

            employee.FirstName = newEmp.First_Name;
            employee.LastName = newEmp.Last_Name;
            employee.Email = newEmp.Email;
            employee.PhoneNo = newEmp.Phone_No;
            employee.AccountId = newEmp.Account_Id;
            employee.Gender = newEmp.Gender;
            employee.Password = newEmp.Password;
            employee.BirthDate = newEmp.Birth_Date;

            return employee;
        }


        // throw new System.NotImplementedException();
         public EmployeeViewModel EmployeeView(Employees employee) {
             var employees = new EmployeeViewModel();
             
             employees.id = employee.Id;
             employees.First_Name = employee.FirstName;
             employees.Last_Name = employee.FirstName;
             employees.Email = employees.Email;
             employees.Phone_No = employee.PhoneNo;
             employees.Birth_Date = employee.BirthDate;
             employees.Gender = employee.Gender;
             employees.Account_Id = (uint) employee.AccountId;
             employees.Date_Created = employee.DateCreated;
             employees.Date_Updated = employee.DateUpdated;

             return employees;

         }

        public Employees UpdatesEmployee(Employees currentEmployee, UpdatedEmployeeDto updateEmployee)
        {
            currentEmployee.LastName = updateEmployee.Last_Name;
            currentEmployee.Email = updateEmployee.Email;
            currentEmployee.PhoneNo = updateEmployee.Phone_No;
            currentEmployee.BirthDate = updateEmployee.Birth_Date;
            currentEmployee.Gender = updateEmployee.Gender;
            currentEmployee.AccountId = updateEmployee.Account_Id;
            currentEmployee.Password = updateEmployee.Password;

            return currentEmployee;
        }
    }
}