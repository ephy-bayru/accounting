/*
 * @CreateTime: Oct 9, 2018 10:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 3:36 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Factories {
    public class CustomerFactory : ICustomerFactory {
        public List<CustomerViewModel> createCustomerView (IEnumerable<Customer> customer) {

            List<CustomerViewModel> customerViews = new List<CustomerViewModel> ();
            List<NewCustomerModel> newCustomers = new List<NewCustomerModel> ();
            List<UpdateCustomerModel> updateCustomers = new List<UpdateCustomerModel> ();

            foreach (var item in customer) {
                CustomerViewModel view = new CustomerViewModel () {
                    id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    Phone_No = item.PhoneNo,
                    Country = item.Country,
                    City = item.City,
                    SubCity = item.SubCity,
                    PostalCode = item.PostalCode,

                };
                customerViews.Add (view);
            }
            return customerViews;
        }

        public Customer NewCustomerAccount (NewCustomerModel customer) {
            Customer newCustomer = new Customer () {
                FullName = customer.FullName,
                City = customer.City,
                Country = customer.Country,
                SubCity = customer.SubCity,
                PhoneNo = customer.Phone_No,
                PostalCode = customer.PostalCode,
                Email = customer.Email,
                HouseNo = customer.HouseNo
            };

            foreach (var account in customer.BankAccounts) {
                newCustomer.CustomerAccount.Add (new CustomerAccount () {
                    AccountNumber = account.AccountNumber,
                        BankName = account.BankName
                });
            }
            return newCustomer;
        }

        public Customer UpdatedCustomer (UpdateCustomerModel update) {
            Customer customer = new Customer () {
                Id = update.id,
                FullName = update.FullName,
                Email = update.Email,
                PhoneNo = update.Phone_No,
                Country = update.Country,
                City = update.City,
                SubCity = update.SubCity,
                PostalCode = update.PostalCode
            };

            foreach (var account in update.BankAccounts) {
                customer.CustomerAccount.Add(new CustomerAccount() {
                    Id = account.Id,
                    BankName = account.BankName,
                    AccountNumber = account.AccountNumber,
                    CustomerId = update.id
                });
            }
            return customer;
        }
    }
}