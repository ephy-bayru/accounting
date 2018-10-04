using System.Collections.Generic;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Employe;
using Smart_Accounting.Domain.Oranizations;
using Smart_Accounting.Domain.Customers;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Application.Supplier.Models;

namespace Smart_Accounting.API.Commons.Factories {
    public interface IResponseFactory {
        ResponseFormat Create (List<CalendarPeriod> calander);
        ResponseFormat CreateOrganizationResponse (List<OrganizationViewModel> organizations);
        ResponseFormat CreateEmployeeResponse (List<EmployeeViewModel> employees);
        ResponseFormat CreateCustomerResonse (List<CustomerViewModel> customer);
        ResponseFormat CreateSupplierResponse (List<SupplierViewModel> suppliers);
    }
}