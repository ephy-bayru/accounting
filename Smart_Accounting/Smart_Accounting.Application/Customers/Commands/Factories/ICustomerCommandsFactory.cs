using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Commands.Factories {
    public interface ICustomerCommandsFactory {
        Customer NewCustomer (NewCustomerModel newCustomer);
        Customer UpdatesCustomer(Customer currentCustomer, UpdateCustomerModel customer);
        CustomerViewModel CustomerView(Customer customer);
    }
}