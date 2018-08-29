using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Queries {
    public class EmployeesQuery : IEmployeesQueries {

        private IAccountingDatabaseService _database;
        public EmployeesQuery(IAccountingDatabaseService database) {
            _database = database;
        }
        public IEnumerable<Employees> GetAll () {
          return _database.Employees.ToList();
        }

        public Employees GetById (uint employeeId) {
            throw new System.NotImplementedException ();
        }
    }
}