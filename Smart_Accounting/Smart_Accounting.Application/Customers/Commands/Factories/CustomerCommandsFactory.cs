using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Commands.Factories {
    public class CustomerCommandsFactory : ICustomerCommandsFactory {
        public Customer NewCustomer (NewCustomerModel newCustomer) {
            var customer = new Customer ();

            customer.FullName = newCustomer.FullName;
            customer.Account_Number = newCustomer.Account_Number;
            customer.Email = newCustomer.Email;
            customer.PhoneNo = newCustomer.Phone_No;
            customer.Country = newCustomer.Country;
            customer.City = newCustomer.City;
            customer.SubCity = newCustomer.SubCity;
            customer.HouseNo = newCustomer.HouseNo;
            customer.PostalCode = newCustomer.PostalCode;

            return customer;
        }

        public CustomerViewModel CustomerView (Customer customer) {
            var customers = new CustomerViewModel ();

            customer.Id = customer.Id;
            customer.FullName = customer.FullName;
            customer.Account_Number = customer.Account_Number;
            customer.Email = customer.Email;
            customer.PhoneNo = customer.PhoneNo;
            customer.Country = customer.Country;
            customer.City = customer.City;
            customer.SubCity = customer.SubCity;
            customer.HouseNo = customer.HouseNo;
            customer.PostalCode = customer.PostalCode;

            return customers;

        }

        public Customer UpdatesCustomer (Customer currentCustomer, UpdateCustomerModel updateCustomer) {
            currentCustomer.FullName = currentCustomer.FullName;
            currentCustomer.Account_Number = currentCustomer.Account_Number;
            currentCustomer.Email = currentCustomer.Email;
            currentCustomer.PhoneNo = currentCustomer.PhoneNo;
            currentCustomer.Country = currentCustomer.Country;
            currentCustomer.City = currentCustomer.City;
            currentCustomer.SubCity = currentCustomer.SubCity;
            currentCustomer.HouseNo = currentCustomer.HouseNo;
            currentCustomer.PostalCode = currentCustomer.PostalCode;

            return currentCustomer;
        }
    }
}