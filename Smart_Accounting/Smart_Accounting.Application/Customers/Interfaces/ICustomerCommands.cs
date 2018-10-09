using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Interfaces {
    public interface ICustomerCommands {
        Customer Create (Customer newCustomer);
        void Update (Customer customer, UpdateCustomerModel updateCustomer);
        void Delete (Customer customer);
    }
}