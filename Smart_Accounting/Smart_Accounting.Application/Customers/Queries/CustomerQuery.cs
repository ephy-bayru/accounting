/*
 * @CreateTime: Oct 9, 2018 3:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 3:39 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Queries {
    public class CustomerQuery : ICustomerQuery {
        private readonly IAccountingDatabaseService _database;
        public ICustomerCommandsFactory _factory;

        public CustomerQuery (
            IAccountingDatabaseService database,
            ICustomerCommandsFactory factory
        ) {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<Customer> GetAll () {
            return _database.Customer.AsNoTracking ().ToList ();
        }

        public Customer GetById (uint id) {
            var customer = _database.Customer.AsNoTracking ().Where (cus => cus.Id == id).FirstOrDefault ();
            return customer;
        }

    }
}