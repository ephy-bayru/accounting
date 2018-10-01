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

namespace Smart_Accounting.API.NUnitTest.Customers
{
    [TestFixture]
    public class CustomersControllerTEST
    {
        private Customer customer;
        private NewCustomerModel newCustomer;
        private CustomerViewModel customerView;
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
            customer = new Customer()
            {
                Id = 1,
                FullName = "Microsoft",
                AccountId = 123456,
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
            customerView = new CustomerViewModel()
            {
                id = 1,
                FullName = "Microsoft",
                AccountId = 123456,
                Email = "e@g.com",
                PhoneNo = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                PostalCode = "123456",
            };
            var MockHttpContext = new Mock<HttpContext>();
            MockICustomerCommand = new Mock<ICustomerCommands>();
            MockIResponseFactory = new Mock<IResponseFactory>();
            MockICustomerFactory = new Mock<ICustomerFactory>();
            MockICustomerQuery = new Mock<ICustomerQuery>();
            MockLoggerFactory = new Mock<ILoggerFactory>();

            MockICustomerFactory.Setup(factory => factory.createCustomerView(customer));
            MockICustomerQuery.Setup(query => query.GetById(id)).Returns(customer);
            MockLoggerFactory.Setup(p => p.CreateLogger(It.IsAny<string>())).Returns(Mock.Of<ILogger>());
      
        CustomersController = new CustomersController(
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockICustomerQuery.Object,
                MockIResponseFactory.Object
            );

    }

}
