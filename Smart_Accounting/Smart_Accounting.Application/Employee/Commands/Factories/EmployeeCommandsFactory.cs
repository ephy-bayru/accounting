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

        public Employees UpdateEmployee(Employee employee, UpdatedEmployeeModel updateEmployee)
        {
            employee.First_Name = updateEmployee.First_Name;
            employee.Last_Name = updateEmployee.Last_Name;
            employee.Email = updateEmployee.Email;
            employee.Phone_No = updateEmployee.Phone_No;
            employee.Birth_Date = updateEmployee.Birth_Date;
            employee.Gender = updateEmployee.Gender;
            employee.Account_Id = updateEmployee.Account_Id;
            employee.Password = updateEmployee.Password;

            return employee;
        }
        // throw new System.NotImplementedException();
         public EmployeeViewModel EmployeeView(Employee employee) {
             var employees = new EmployeeViewModel();
             
             employees.id = employee.id;
             employees.First_Name = employee.First_Name;
             employees.Last_Name = employee.First_Name;
             employees.Email = employees.Email;
             employees.Phone_No = employee.Phone_No;
             employees.Birth_Date = employee.Birth_Date;
             employees.Gender = employee.Gender;
             employees.Account_Id = employee.Account_Id
             employees.Password = employee.Password;

             return employees;

         }
    }
}