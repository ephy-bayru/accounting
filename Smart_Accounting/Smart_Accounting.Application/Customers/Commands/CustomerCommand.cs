/*
 * @CreateTime: Oct 9, 2018 10:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 10:45 AM
 * @Description: Modify Here, Please 
 */
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

        public void Delete (Customer customer) {
            _database.Customer.Remove (customer);
            _database.Save ();
        }

        public void delete (Customer customer) {
            throw new System.NotImplementedException ();
        }

        public void Update (Customer customer, UpdateCustomerModel updatecustomer) {
            var cstmr = customerCommandFactory.UpdatesCustomer (customer, updatecustomer);
            _database.Customer.Update (cstmr);
            _database.Save ();
        }

        public void update (UpdateCustomerModel updateCustomer, Customer customer) {
            throw new System.NotImplementedException ();
        }

    }
}