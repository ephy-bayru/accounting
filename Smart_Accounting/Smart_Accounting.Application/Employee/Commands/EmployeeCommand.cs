using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands {
    public class EmployeeCommand : IEmployeeCommands {

        private readonly IAccountingDatabaseService _database;
        private IEmployeeCommandsFactory _employeeCmdFactory;
        public EmployeeCommand(IAccountingDatabaseService database,
                                IEmployeeCommandsFactory employeeCmdFactory) {
            _database = database;
            _employeeCmdFactory = employeeCmdFactory;
        }
        public void Create (NewEmployeeModel newEmployee) {
            var employee = _employeeCmdFactory.NewEmployee(newEmployee);

            _database.Employees.Add(employee);
            _database.Save();
            
        }

        public void Delete (Employees employee) {
            _database.Employees.Remove(employee);
            _database.Save();
        }

        public void Update (Employees employee, UpdatedEmployeeModel updatedEmployee ) {
            var employee = _employeeCmdFactory.UpdateEmployee(employee, updatedEmployee);
            _database.Employee.Update(employee);
            _database.Save();
            return true;
        }
    }
}