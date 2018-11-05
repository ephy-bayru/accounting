/*
 * @CreateTime: Oct 9, 2018 3:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:45 PM
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
            IAccountingDatabaseService database
        ) {
            _database = database;
        }
        public IEnumerable<Customer> GetAll () {
            return _database.Customer.Select (customer => new Customer () {
                    FullName = customer.FullName,
                    Email = customer.Email,
                    City = customer.City,
                    Country = customer.Country,
                    PostalCode = customer.PostalCode,
                    PhoneNo = customer.PhoneNo,
                    HouseNo = customer.HouseNo,
                    Id = customer.Id,
                    SubCity = customer.SubCity,
                    CreditLimit = customer.CreditLimit,
                    Balance = customer.Balance,
                    Active = customer.Active,
                    Blocked = customer.Blocked,
                    DateCreated = customer.DateCreated,
                    DateUpdated = customer.DateUpdated
            }).ToList ();
        }

        public IEnumerable<CustomerAccount> GetAllCustomerAccounts () {
            return _database.CustomerAccounts.Select (account => new CustomerAccount () {
                AccountNumber = account.AccountNumber,
                    BankName = account.BankName,
                    CustomerId = account.CustomerId,
                    Id = account.Id
            }).ToList ();
        }

        public Customer GetById (uint id) {
            return _database.Customer.Where (cus => cus.Id == id)
                .Select (customer => new Customer () {
                    FullName = customer.FullName,
                        Email = customer.Email,
                        City = customer.City,
                        Country = customer.Country,
                        PostalCode = customer.PostalCode,
                        PhoneNo = customer.PhoneNo,
                        HouseNo = customer.HouseNo,
                        Id = customer.Id,
                        SubCity = customer.SubCity,
                        CreditLimit = customer.CreditLimit,
                        Balance = customer.Balance,
                        Active = customer.Active,
                        Blocked = customer.Blocked,
                        DateCreated = customer.DateCreated,
                        DateUpdated = customer.DateUpdated,
                        CustomerAccount = customer.CustomerAccount.Select (account => new CustomerAccount () {
                            AccountNumber = account.AccountNumber,
                                BankName = account.BankName,
                                CustomerId = account.CustomerId,
                                Id = account.Id
                        }).ToList ()
                }).FirstOrDefault ();
        }

        public CustomerAccount GetCustomerAccountById (uint id) {
            return _database.CustomerAccounts.Where (cusAccount => cusAccount.Id == id)
                .Select (account => new CustomerAccount () {
                    AccountNumber = account.AccountNumber,
                        BankName = account.BankName,
                        CustomerId = account.CustomerId,
                        Id = account.Id
                }).FirstOrDefault ();
        }
    }
}