using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Commands {
    public class CustomerCommand : ICustomerCommands {
        private readonly IAccountingDatabaseService _database;
        private ICustomerCommandsFactory customerCommandFactory;
        public CustomerCommand(IAccountingDatabaseService database,
                               ICustomerCommandsFactory CustomerCommandFactory)
        {
            _database = database;
            customerCommandFactory = CustomerCommandFactory;
        }
        public void Create(NewCustomerModel newCustomer)
        {
            var customer = customerCommandFactory.NewCustomer(newCustomer);

            _database.Customer.Add(customer);
            _database.Save();

        }

        public void Delete(Customer customer)
        {
            _database.Customer.Remove(customer);
            _database.Save();
        }

        public void delete(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer customer, UpdateCustomerModel updatecustomer)
        {
            var cstmr = customerCommandFactory.UpdatesCustomer(customer, updatecustomer);
            _database.Customer.Update(cstmr);
            _database.Save();
        }

        public void update(UpdateCustomerModel updateCustomer, Customer customer)
        {
            throw new System.NotImplementedException();
        }

    }
}