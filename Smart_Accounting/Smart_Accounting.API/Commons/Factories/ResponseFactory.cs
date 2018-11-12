/*
 * @CreateTime: Nov 12, 2018 10:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 10:27 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Employe;
using Smart_Accounting.Domain.ExchangeRates;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.API.Commons.Factories {
    public class ResponseFactory : IResponseFactory {
        public ResponseFormat Create (List<CalendarPeriod> calander) {
            ResponseFormat response = new ResponseFormat();
            response.Items = new List<CalendarPeriod>();
            foreach (var item in calander) {
                response.Items.Add(item);
            }
            response.Count = calander.Count;
            return response;
        }

        public ResponseFormat CreateCurrencyResponse (List<CurrencyViewModel> currencies) {
            ResponseFormat format = new ResponseFormat () {
                Items = currencies
            };
            return format;
        }

        public ResponseFormat CreateCustomerResonse (List<CustomerViewModel> customer) {
            ResponseFormat format = new ResponseFormat () {
                Items = customer,
                Count = customer.Count
            };

            return format;
        }

        public ResponseFormat CreateEmployeeResponse (List<EmployeeViewModel> employee) {
            ResponseFormat format = new ResponseFormat () {
                Items = employee,
                Count = employee.Count
            };

            return format;
        }

        public ResponseFormat CreateExRateResponse (List<ExchangeRate> exchangeRates) {
            throw new System.NotImplementedException ();
        }

        public ResponseFormat CreateOrganizationResponse (List<OrganizationViewModel> organizations) {
            ResponseFormat format = new ResponseFormat () {
                Items = organizations,
                Count = organizations.Count
            };

            return format;
        }

        public ResponseFormat CreateSupplierResponse (List<SupplierViewModel> suppliers) {
            ResponseFormat format = new ResponseFormat () {
                Items = suppliers,
            };

            return format;
        }
    }
}