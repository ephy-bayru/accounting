using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Interfaces {
    public interface IEmployeeCommands {
        void Create (NewEmployeeModel newEmployee);
        void Update ();
        void Delete (Employees employee);
    }
}