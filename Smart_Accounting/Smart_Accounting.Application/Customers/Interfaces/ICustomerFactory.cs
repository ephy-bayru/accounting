using System.Collections.Generic;
using Smart_Accounting.Domain.Customers;
using Smart_Accounting.Application.Customers.Models;

namespace Smart_Accounting.Application.Customers.Interfaces
{
    public interface ICustomerFactory
    {
        List<CustomerViewModel> createCustomerView(IEnumerable<Customer> customer);
        Customer NewCustomerAccount(NewCustomerModel customer);

        Customer UpdatedCustomer(UpdateCustomerModel customer);
    }
}