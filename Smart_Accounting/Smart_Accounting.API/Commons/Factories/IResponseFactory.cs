/*
 * @CreateTime: Nov 12, 2018 10:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 10:22 AM
 * @Description: Modify Here, Please 
 */
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
using Smart_Accounting.Domain.Currencies;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Domain.ExchangeRates;


namespace Smart_Accounting.API.Commons.Factories {
    public interface IResponseFactory {
        ResponseFormat Create (List<CalendarPeriod> calander);
        ResponseFormat CreateOrganizationResponse (List<OrganizationViewModel> organizations);
        ResponseFormat CreateEmployeeResponse (List<EmployeeViewModel> employees);
        ResponseFormat CreateCustomerResonse (List<CustomerViewModel> customer);
        ResponseFormat CreateSupplierResponse (List<SupplierViewModel> suppliers);
        ResponseFormat CreateCurrencyResponse (List<CurrencyViewModel> currencies);
        ResponseFormat CreateExRateResponse (List<ExchangeRate> exchangeRates);
    }
}