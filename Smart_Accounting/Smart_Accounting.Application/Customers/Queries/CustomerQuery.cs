using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.Customers.Factories;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Queries
{
    public class CustomerQuery : ICustomerQuery
    {   
        private readonly IAccountingDatabaseService _database;
        public ICustomerFactory _factory;

        public CustomerQuery(
            IAccountingDatabaseService database,
            ICustomerFactory  factory
         ) {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _database.Customer.ToList();
        }

        public Customer GetById(uint id)
        {
            var customer = _database.Customer.Find(id);
            return customer;
        }
       
    }
}