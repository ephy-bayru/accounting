using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Interfaces {
    public interface IEmployeesQueries {
        Employees GetById (uint employeeId);
    }
}