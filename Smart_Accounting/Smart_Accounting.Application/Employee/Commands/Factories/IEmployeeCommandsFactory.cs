using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Commands.Factories {
    public interface IEmployeeCommandsFactory {
        Employees NewEmployee (NewEmployeeModel newEmp);
        Employees UpdatesEmployee(Employee currentEmployee, UpdatedEmployeeModel employee);
        EmployeeViewModel EmployeeView(Employee employee);
    }
}