using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Interfaces {
    public interface IEmployeeCommands {
        void Create (Employees employees);
        void Update (Employees employee, UpdatedEmployeeDto updateEmployee);
        void Delete (Employees employee);
    }
}