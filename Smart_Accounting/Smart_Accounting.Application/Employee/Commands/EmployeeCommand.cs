using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands
{
    public class EmployeeCommand : IEmployeeCommands
    {

        private readonly IAccountingDatabaseService _database;
        private IEmployeeCommandsFactory _employeeCmdFactory;
        public EmployeeCommand( IAccountingDatabaseService database,
                                IEmployeeCommandsFactory employeeCmdFactory)
        {
            _database = database;
            _employeeCmdFactory = employeeCmdFactory;
        }
        public void Create(Employees employees)
        {
            _database.Employees.Add(employees);
            _database.Save();

        }

        public void Delete(Employees employee)
        {
            _database.Employees.Remove(employee);
            _database.Save();
        }

        public void Update(Employees employee, UpdatedEmployeeDto updatedEmployee)
        {
            var emp = _employeeCmdFactory.UpdatesEmployee(employee, updatedEmployee);
            _database.Employees.Update(emp);
            _database.Save();
        }

    }
}