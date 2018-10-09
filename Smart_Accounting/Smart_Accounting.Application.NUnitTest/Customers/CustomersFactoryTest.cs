/*
 * @CreateTime: Oct 9, 2018 9:41 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 9:41 AM
 * @Description: Modify Here, Please 
 */
using System;
using NUnit.Framework;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;


namespace Smart_Accounting.Application.NUnitTest.Customers.Factories
{
    [TestFixture]
    public class CustomersFactoryTest
    {

        private UpdateCustomerModel updateCustomersModel;
        private CustomerCommandsFactory customersCommandFactory;
        private NewCustomerModel newCustomerModel;

        [OneTimeSetUp]

        public void Cust()
        {
            newCustomerModel = new NewCustomerModel();
            updateCustomersModel = new UpdateCustomerModel();
            customersCommandFactory = new CustomerCommandsFactory();

            newCustomerModel.FullName = "Microsoft";
            newCustomerModel.Phone_No = "0920208549";
            newCustomerModel.Email = "email";
            newCustomerModel.Country = "Ethiopia";
            newCustomerModel.City = "Dessie";
            newCustomerModel.SubCity = "gtz";
            newCustomerModel.HouseNo = "123456";
            newCustomerModel.PostalCode = "123456";

            // Update customer model
            updateCustomersModel.id = 2;
            updateCustomersModel.FullName = "Microsoft";
            updateCustomersModel.Phone_No = "0920208549";
            updateCustomersModel.Email = "email";
            updateCustomersModel.Country = "Ethiopia";
            updateCustomersModel.City = "Dessie";
            updateCustomersModel.SubCity = "gtz";
            updateCustomersModel.HouseNo = "123456";
            updateCustomersModel.PostalCode = "123456";

        }
        [Test]
        public void NewCustomerTest()
        {
            Customer customer = customersCommandFactory.NewCustomer(newCustomerModel);

            Assert.That(customer.Id, Is.EqualTo(1));
            Assert.That(customer.FullName, Is.EqualTo("Microsoft"));
            Assert.That(customer.PhoneNo, Is.EqualTo("0920208549"));
            Assert.That(customer.Email, Is.EqualTo("mail"));
            Assert.That(customer.Country, Is.EqualTo("Ethiopia"));
            Assert.That(customer.City, Is.EqualTo("Adis"));
            Assert.That(customer.SubCity, Is.EqualTo("Bole"));
            Assert.That(customer.HouseNo, Is.EqualTo("123456"));
            Assert.That(customer.PostalCode, Is.EqualTo(123456));

        }
        [Test]
        public void UpdateCustomerTest()
        {
            Customer currentCustomer = new Customer()
            {
                Id = 2,
                FullName = "Microsoft",
                PhoneNo = "0920208549",
                Email = "email",
                Country = "Ethiopia",
                City = "Dessie",
                SubCity = "gtz",
                HouseNo = "123456",
                PostalCode = "123456"
            };
            Customer customer = customersCommandFactory.UpdatesCustomer(currentCustomer, updateCustomersModel);
            Assert.That(customer.Id, Is.EqualTo(1));
            Assert.That(customer.FullName, Is.EqualTo("Microsoft"));
            Assert.That(customer.PhoneNo, Is.EqualTo(0920208549));
            Assert.That(customer.Email, Is.EqualTo("email"));
            Assert.That(customer.Country, Is.EqualTo("Ethiopia"));
            Assert.That(customer.City, Is.EqualTo("Dessie"));
            Assert.That(customer.SubCity, Is.EqualTo("gtz"));
            Assert.That(customer.HouseNo, Is.EqualTo("123456"));
            Assert.That(customer.PostalCode, Is.EqualTo(123456));

        }
        [Test]
        public void CustomerViewTest()
        {
            Customer customer = new Customer()
            {
                Id = 2,
                FullName = "Microsoft",
                PhoneNo = "0920208549",
                Email = "email",
                Country = "Ethiopia",
                City = "Dessie",
                SubCity = "gtz",
                HouseNo = "123456",
                PostalCode = "123456"
            };
            CustomerViewModel cstmr = customersCommandFactory.CustomerView(customer);

            Assert.That(customer.Id, Is.EqualTo(1));
            Assert.That(customer.FullName, Is.EqualTo(customer.FullName));
            Assert.That(customer.PhoneNo, Is.EqualTo(customer.PhoneNo));
            Assert.That(customer.Email, Is.EqualTo(customer.Email));
            Assert.That(customer.Country, Is.EqualTo(customer.Country));
            Assert.That(customer.City, Is.EqualTo(customer.City));
            Assert.That(customer.SubCity, Is.EqualTo(customer.SubCity));
            Assert.That(customer.HouseNo, Is.EqualTo(customer.HouseNo));
            Assert.That(customer.PostalCode, Is.EqualTo(customer.PostalCode));

        }

    }
}