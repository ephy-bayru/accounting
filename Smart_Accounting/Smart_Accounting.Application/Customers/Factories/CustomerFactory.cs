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

            foreach (var item in customer)
            {
                CustomerViewModel view = new CustomerViewModel()
                {
                    id = item.Id,
                    FullName = item.FullName,
                    AccountId = item.AccountId,
                    AccountNumber = item.AccountNumber,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    Country = item.Country,
                    City = item.City,
                    SubCity = item.SubCity,
                    PostalCode = item.PostalCode
                };
                customerViews.Add(view);
            }
            return customerViews;
        }
    }
}