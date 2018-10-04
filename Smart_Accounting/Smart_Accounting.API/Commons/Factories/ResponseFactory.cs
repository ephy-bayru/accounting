using System.Collections.Generic;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Employe;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.API.Commons.Factories
{
    public class ResponseFactory : IResponseFactory
    {
        public ResponseFormat Create(List<CalendarPeriod> calander)
        {
            ResponseFormat format = new ResponseFormat() {
                Items = calander,
                Count = calander.Count
            };

            return format;
        }

        public ResponseFormat CreateCustomerResonse(List<CustomerViewModel> customer)
        {
            ResponseFormat format = new ResponseFormat() {
                Items = customer,
                Count = customer.Count
            };

            return format;
        }

        public ResponseFormat CreateEmployeeResponse(List<EmployeeViewModel> employee)
        {
           ResponseFormat format = new ResponseFormat() {
                Items = employee,
                Count = employee.Count
            };

            return format;
        }

        public ResponseFormat CreateOrganizationResponse(List<OrganizationViewModel> organizations)
        {
            ResponseFormat format = new ResponseFormat() {
                Items = organizations,
                Count = organizations.Count
            };

            return format;
        }

        public ResponseFormat CreateSupplierResponse(List<SupplierViewModel> suppliers)
        {
            ResponseFormat format = new ResponseFormat() {
                Items = suppliers,
            };

            return format;
        }
    }
}