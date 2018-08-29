using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands.Factories
{
    public class EmployeeCommandsFactory : IEmployeeCommandsFactory
    {
        public Employees NewEmployee(NewEmployeeModel data)
        {
            var employee = new  Employees();

            employee.Name = data.Name;

            employee.CreditLimit = 400;

            employee.AccountId = 1;

            return employee;
        }

        public Employees UpdatesEmployee()
        {
            throw new System.NotImplementedException();
        }
    }
}