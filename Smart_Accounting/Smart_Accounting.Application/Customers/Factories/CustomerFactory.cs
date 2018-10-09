using System.Collections.Generic;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public List<CustomerViewModel> createCustomerView(IEnumerable<Customer> customer)
        {

            List<CustomerViewModel> customerViews = new List<CustomerViewModel>();
            List<NewCustomerModel> newCustomers = new List<NewCustomerModel>();
            List<UpdateCustomerModel> updateCustomers = new List<UpdateCustomerModel> ();

            foreach (var item in customer)
            {
                CustomerViewModel view = new CustomerViewModel()
                {
                    id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    Country = item.Country,
                    City = item.City,
                    SubCity = item.SubCity,
                    PostalCode = item.PostalCode,
                    
                };
                customerViews.Add(view);
            }
            return customerViews;
        }
        public Customer updateCustomers (UpdateCustomerModel update) {
            Customer customer = new Customer() {
                FullName = update.FullName,
                Email = update.Email,
                PhoneNo = update.Phone_No,
                Country = update.Country,
                City = update.City,
                SubCity = update.SubCity,
                PostalCode = update.PostalCode,
                CustomerAccount = new List<CustomerAccount>() {
                    new CustomerAccount() {
                    }
                }
            };
            return customer;
        }
    }
}