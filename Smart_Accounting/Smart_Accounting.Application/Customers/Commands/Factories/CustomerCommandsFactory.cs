/*
 * @CreateTime: Oct 9, 2018 9:38 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:43 PM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Commands.Factories {
    public class CustomerCommandsFactory : ICustomerCommandsFactory {
        public Customer NewCustomer (NewCustomerModel newCustomer) {
            var customer = new Customer ();

            customer.FullName = newCustomer.FullName;
            customer.Email = newCustomer.Email;
            customer.PhoneNo = newCustomer.Phone_No;
            customer.Country = newCustomer.Country;
            customer.City = newCustomer.City;
            customer.SubCity = newCustomer.SubCity;
            customer.HouseNo = newCustomer.HouseNo;
            customer.PostalCode = newCustomer.PostalCode;
            customer.CreditLimit =newCustomer.CreditLimit;
            customer.Balance = newCustomer.Balance;
            customer.Active = newCustomer.Active;
            customer.Blocked = newCustomer.Blocked;

            return customer;
        }

        public CustomerViewModel CustomerView (Customer customer) {
            var customers = new CustomerViewModel ();

            customer.Id = customers.id;
            customer.FullName = customers.FullName;
            customer.Email = customers.Email;
            customer.PhoneNo = customers.Phone_No;
            customer.Country = customers.Country;
            customer.City = customers.City;
            customer.SubCity = customers.SubCity;
            customer.HouseNo = customers.HouseNo;
            customer.PostalCode = customers.PostalCode;
            customer.Balance = customers.Balance;
            customer.CreditLimit = customers.CreditLimit;
            customer.Active = customers.Active;
            customer.Blocked = customers.Blocked;

            return customers;

        }

        public Customer UpdatesCustomer (Customer currentCustomer, UpdateCustomerModel updateCustomer) {
            currentCustomer.FullName = updateCustomer.FullName;
            currentCustomer.Email = updateCustomer.Email;
            currentCustomer.PhoneNo = updateCustomer.Phone_No;
            currentCustomer.Country = updateCustomer.Country;
            currentCustomer.City = updateCustomer.City;
            currentCustomer.SubCity = updateCustomer.SubCity;
            currentCustomer.HouseNo = updateCustomer.HouseNo;
            currentCustomer.PostalCode = updateCustomer.PostalCode;
            currentCustomer.Balance = updateCustomer.Balance;
            currentCustomer.CreditLimit = updateCustomer.CreditLimit;
            currentCustomer.Active = updateCustomer.Active;
            currentCustomer.Blocked = updateCustomer.Blocked;

            return currentCustomer;
        }
    }
}