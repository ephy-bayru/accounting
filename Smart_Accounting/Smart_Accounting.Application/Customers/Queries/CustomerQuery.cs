using System.Collections.Generic;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Queries
{
    public class CustomerQuery : ICustomerQuery
    {
        public IEnumerable<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(uint customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}