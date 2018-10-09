/*
 * @CreateTime: Oct 9, 2018 10:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 3:34 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Commands {
    public class CustomerCommand : ICustomerCommands {
        private readonly IAccountingDatabaseService _database;
        private ICustomerCommandsFactory customerCommandFactory;
        public CustomerCommand (IAccountingDatabaseService database,
            ICustomerCommandsFactory CustomerCommandFactory) {
            _database = database;
            customerCommandFactory = CustomerCommandFactory;
        }
        public Customer Create (Customer newCustomer) {

            _database.Customer.Add (newCustomer);
            _database.Save ();

            return newCustomer;

        }

        public bool Delete (Customer customer) {
            _database.Customer.Remove(customer);
            return true;
        }
        public bool Update (Customer customer) {
            _database.Customer.Update (customer).State = EntityState.Modified;
            _database.Save ();
            return true;
        }

    }
}