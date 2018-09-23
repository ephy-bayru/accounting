using System.Collections.Generic;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Application.Employee.Interfaces
{
    public interface IEmployeeFactory
    {
        List<EmployeeViewModel> createEmployeeView(IEnumerable<Employees> employee);
    }
}