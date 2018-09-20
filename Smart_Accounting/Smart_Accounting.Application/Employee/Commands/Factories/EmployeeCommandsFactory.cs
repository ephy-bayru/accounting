using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands.Factories
{
    public class EmployeeCommandsFactory : IEmployeeCommandsFactory
    {
        public Employees NewEmployee(NewEmployeeModel newEmp)
        {
            var employee = new  Employees();

            employee.First_Name = newEmp.First_Name;
            employee.Last_Name = newEmp.Last_Name;
            employee.Email = newEmp.Email;
            employee.Phone_No = newEmp.Phone_No;
            employee.Account_Id = newEmp.Account_Id;
            employee.Gender = newEmp.Gender;
            employee.Password = newEmp.Password;
            employee.Birth_Date = newEmp.Birth_Date;

            return employee;
        }


        // throw new System.NotImplementedException();
         public EmployeeViewModel EmployeeView(Employees employee) {
             var employees = new EmployeeViewModel();
             
             employees.id = employee.Id;
             employees.First_Name = employee.First_Name;
             employees.Last_Name = employee.First_Name;
             employees.Email = employees.Email;
             employees.Phone_No = employee.Phone_No;
             employees.Birth_Date = employee.Birth_Date;
             employees.Gender = employee.Gender;
             employees.Account_Id = employee.Account_Id;
             employees.Date_Created = employee.Date_Created;
             employees.Date_Updated = employee.Date_Updated;

             return employees;

         }

        public Employees UpdatesEmployee(Employees currentEmployee, UpdatedEmployeeDto updateEmployee)
        {
            currentEmployee.Last_Name = updateEmployee.Last_Name;
            currentEmployee.Email = updateEmployee.Email;
            currentEmployee.Phone_No = updateEmployee.Phone_No;
            currentEmployee.Birth_Date = updateEmployee.Birth_Date;
            currentEmployee.Gender = updateEmployee.Gender;
            currentEmployee.Account_Id = updateEmployee.Account_Id;
            currentEmployee.Password = updateEmployee.Password;

            return currentEmployee;
        }
    }
}