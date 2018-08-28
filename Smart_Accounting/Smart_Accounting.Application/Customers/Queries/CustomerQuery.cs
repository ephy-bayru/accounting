using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Queries
{
    public class CustomerQuery : ICustomerQuery
    {   
        private readonly IAccountingDatabaseService _database;

        public CustomerQuery(IAccountingDatabaseService database ) {
            _database = database;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _database.Customer.ToList();
        }

        public Customer GetById(uint customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}