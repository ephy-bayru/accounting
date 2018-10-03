using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Employe;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Accounting.Application.Employee.Queries
{
    public class EmployeesQuery : IEmployeesQueries
    {

        private IAccountingDatabaseService _database;
        public IEmployeeCommandsFactory _factory;
        public EmployeesQuery(IAccountingDatabaseService database,
            IEmployeeCommandsFactory factory)
        {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<Employees> GetAll()
        {
            return _database.Employees.AsNoTracking().ToList();
        }

        public Employees GetById(uint id)
        {
            var employee = _database.Employees.Find(id);
            return employee;
        }

    }
}