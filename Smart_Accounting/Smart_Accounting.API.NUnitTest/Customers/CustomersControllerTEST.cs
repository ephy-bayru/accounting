/*
 * @CreateTime: Oct 9, 2018 9:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 11:18 AM
 * @Description: Modify Here, Please 
 */
using System;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Factories;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.API.Controllers.Customers;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Domain.Customers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Net.Http;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace Smart_Accounting.API.NUnitTest.Customers
{
    [TestFixture]
    public class CustomersControllerTEST
    {
        private List<Customer> customer;
        private Customer cstmr;
        private NewCustomerModel newCustomer;
        private List<CustomerViewModel> customerView;
        private CustomersController customersController;
        private Mock<ICustomerCommands> MockICustomerCommand;
        private Mock<ICustomerFactory> MockICustomerFactory;
        private Mock<ICustomerQuery> MockICustomerQuery;
        private Mock<IResponseFactory> MockIResponseFactory;
        private Mock<ILoggerFactory> MockLoggerFactory;
        private Mock<HttpContext> MockHttpContext;
        private uint id;

        [OneTimeSetUp]
        public void TestSetup()
        {
            customer = new List<Customer>();
            customer.Add(new Customer()
            {
                Id = 1,
                FullName = "Microsoft",
                Email = "e@g.com",
                PhoneNo = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });

            cstmr = new Customer()
            {
                Id = 1,
                FullName = "Microsoft",
                Email = "e@g.com",
                PhoneNo = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            customerView = new List<CustomerViewModel>();
            customerView.Add(new CustomerViewModel()
            {
                id = 1,
                FullName = "Microsoft",
                Email = "e@g.com",
                PhoneNo = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                PostalCode = "123456",
            });

            var MockHttpContext = new Mock<HttpContext>();
            MockICustomerCommand = new Mock<ICustomerCommands>();
            MockIResponseFactory = new Mock<IResponseFactory>();
            MockICustomerFactory = new Mock<ICustomerFactory>();
            MockICustomerQuery = new Mock<ICustomerQuery>();
            MockLoggerFactory = new Mock<ILoggerFactory>();

            MockICustomerFactory.Setup(factory => factory.createCustomerView(customer)).Returns(customerView);
            MockICustomerQuery.Setup(query => query.GetById(id)).Returns(cstmr);
            MockLoggerFactory.Setup(C => C.CreateLogger(It.IsAny<string>())).Returns(Mock.Of<ILogger>());

            // var CustomersController = new CustomersController(
            //        MockICustomerCommand.Object,
            //        MockICustomerFactory.Object,
            //        MockICustomerQuery.Object,
            //        MockIResponseFactory.Object,
            //        MockILoggerFactory.Object
            //    );
        }

        [Test]
        public void GetAllCustomers_Test()
        {
            var result = (ObjectResult)customersController.GetAllCustomers();
            Assert.AreEqual(customerView, result);
            result.Value.GetType().Should().Be(typeof(CustomerViewModel));
            result.StatusCode.Equals(200);
            Assert.DoesNotThrow(() => { customersController.Response.StatusCode = 500; });
        }
        [Test]
        public void GetCustomersById_Test()
        {
            var result = (ObjectResult)customersController.GetCustomerById(id);
            Assert.AreEqual(customerView, result);
            result.StatusCode.Equals(200);
            Assert.DoesNotThrow(() => { customersController.Response.StatusCode = 500; });
        }
        [Test]
        public void GetNonExistingCustomer_Test()
        {
            uint nonExistingCustomerId = 5;
            var result = (StatusCodeResult)customersController.GetCustomerById(nonExistingCustomerId);
            result.StatusCode.Equals(404);
        }
        [Test]
        public void AddNewCustomer_Test()
        {
            newCustomer = new NewCustomerModel()
            {
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
            };
       //     MockICustomerCommand.Setup(cstmr => cstmr.Create(newCustomer));

            // customersController = new CustomersController(
            //     MockIResponseFactory.Object
            // );

            var result = (ObjectResult)customersController.CreateNewCustomer(newCustomer);

            result.StatusCode.Should().Be(201);
            result.Value.GetType().Should().Be(typeof(CustomerViewModel));
        }
        [Test]
        public void AddNewCustoerWithFalseModel_Test()
        {
            newCustomer = new NewCustomerModel()
            {
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
            };
            // newCustomer falseModel = new NewCustomerModel()
            // {
            //     FullName = "ephrem",
            //     Email = "e@g.com",
            //     Phone_No = "0920208549",
            //     PostalCode = "123456",
            // };
            var result = (ObjectResult)customersController.CreateNewCustomer(newCustomer);
            result.Value.GetType().Should().Be(typeof(CustomerViewModel));
        }

        [Test]
        public void UpdateCustomer_Test()
        {
            UpdateCustomerModel updateCustomer = new UpdateCustomerModel()
            {
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
            };

            MockICustomerCommand.Setup(cmd => cmd.Update(cstmr, updateCustomer));
            // controller

            var result = (StatusCodeResult)customersController.UpdateCustomer(1, updateCustomer);

            result.StatusCode.Should().Be(204);
        }

        [Test]
        public void UpdateNonExistingCustomer()
        {
            UpdateCustomerModel updateCustomer = new UpdateCustomerModel()
            {
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",

            };

            MockICustomerCommand.Setup(cmd => cmd.Update(cstmr, updateCustomer));

            // newCustomer falseModel = new NewCustomerModel()
            // {
            //     FullName = "ephrem",
            //     Email = "e@g.com",
            //     Phone_No = "0920208549",
            //     PostalCode = "123456",
            // };

            var result = (StatusCodeResult)customersController.UpdateCustomer(5, updateCustomer);
            result.StatusCode.Should().Be(404);

        }

        [Test]
        public void DeleteCustomer_Test()
        {
            MockICustomerCommand.Setup(cmd => cmd.Delete(cstmr));

            //     customersController = new CustomersController(
            //      MockIEmployeeCommand.Object,
            //      MockIEmployeeFactory.Object,
            //      MockIEmployeeQuery.Object,
            //      MockIResponseFactory.Object
            //  );

            var result = (StatusCodeResult)customersController.DeleteCustomer(1);
            result.StatusCode.Should().Be(204);
        }

        [Test]
        public void DeleteNonExistingEmployee_Test()
        {
            MockICustomerCommand.Setup(cmd => cmd.Delete(cstmr));

            //     customersController = new CustomersController(
            //      MockIEmployeeCommand.Object,
            //      MockIEmployeeFactory.Object,
            //      MockIEmployeeQuery.Object,
            //      MockIResponseFactory.Object
            //  );

            var result = (StatusCodeResult)customersController.DeleteCustomer(2);
            result.StatusCode.Equals(404);
        }

    }
}
