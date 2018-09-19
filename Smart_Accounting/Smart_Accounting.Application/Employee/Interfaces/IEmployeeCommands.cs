using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Interfaces {
    public interface IEmployeeCommands {
        void Create (NewEmployeeModel newEmployee);
        void Update (Employees employee, UpdatedEmployeeModel updateEmployee);
        void Delete (Employees employee);
    }
}