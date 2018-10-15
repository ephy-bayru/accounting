/*
 * @CreateTime: Oct 9, 2018 9:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 4:21 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.Customers.Factories;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.API.Controllers.Customers;
using Smart_Accounting.Domain.Customers;

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
        private Mock<HttpContext> MockHttpContext;
        private uint id;

//
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────  ──────────
//   :::::: S E T T I N G   U P   D I F F E R E N T   C U S T O M E R S   T E S T   M O D E L S   T H A T   W E   A R E   G O I N G   T O   U S E   I N   O U R   T E S T I N G : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// one time setup!

        [OneTimeSetUp]
        public void TestSetup()
        {

// ─── CUSTOMER MODEL ──────────────────────────────────────────────

            customer = new List<Customer>();
            customer.Add(new Customer()
            {
                Id = 1,
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });

// ─── NEW CUSTOMER MODEL ─────────────────────────────────────────────────────────

            cstmr = new Customer()
            {
                Id = 1,
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Country = "Ethiopia",
                City = "Adis",
                SubCity = "bole",
                HouseNo = "123456",
                PostalCode = "123456",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CustomerAccount = {}
            };

// ─── CUSTOMER VIEW MODEL ────────────────────────────────────────────────────────

            customerView = new List<CustomerViewModel>();
            customerView.Add(new CustomerViewModel()
            {
                id = 1,
                FullName = "Microsoft",
                Email = "e@g.com",
                Phone_No = "0920208549",
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

            MockICustomerFactory.Setup(factory => factory.createCustomerView(customer)).Returns(customerView);
            MockICustomerQuery.Setup(query => query.GetById(id)).Returns(cstmr);

            var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object

               );
        }
// TEST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── I ──────────
//   :::::: G E T   A L L   C U S T O M E S   T E S T   T H A T   W I L L   R E T U R N   2 0 0 : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

        [Test]
        public void GetAllCustomers_Test()
        {
            var result = (ObjectResult)customersController.GetAllCustomers();
            Assert.AreEqual(customerView, result);
            result.Value.GetType().Should().Be(typeof(CustomerViewModel));
            result.StatusCode.Equals(200);
            Assert.DoesNotThrow(() => { customersController.Response.StatusCode = 500; });
        }
// TEST
// ──────────────────────────────────────────────────────────────────────────────────────────────── II ──────────
//   :::::: G E T   A   S I N G L E   U S E R  B Y   T H E I R   I D : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────
//

        [Test]
        public void GetCustomersById_Test()
        {
            var result = (ObjectResult)customersController.GetCustomerById(id);
            Assert.AreEqual(customerView, result);
            result.StatusCode.Equals(200);
            Assert.DoesNotThrow(() => { customersController.Response.StatusCode = 500; });
        }
// TEST
// ──────────────────────────────────────────────────────────────────────────────────────────────── III ──────────
//   :::::: G E T   A   N O N   E X I S T I N G   U S E R   T E S T : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────
//


        [Test]
        public void GetNonExistingCustomer_Test()
        {
            uint nonExistingCustomerId = 5;
            var result = (StatusCodeResult)customersController.GetCustomerById(nonExistingCustomerId);
            result.StatusCode.Equals(404);
        }
// TEST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────── IV ──────────
//   :::::: A D D   A   N E W   C U S T O M E R   T O   D A T A B A S E   T E S T : : RIGHT MODEL : RETURNS  :  200  :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

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
            MockICustomerCommand.Setup(cs => cs.Create(newCustomer));

            var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object
               );

            var result = (ObjectResult)customersController.CreateNewCustomer(newCustomer);

            result.StatusCode.Should().Be(201);
            result.Value.GetType().Should().Be(typeof(CustomerViewModel));
        }

// TEST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── V ──────────
//   :::::: A D D   A   N E W   C U S T O M E R   W I T H   F A L S E   M O D E L   T H E   R E T U R N S   4 2 2 : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

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
            MockICustomerCommand.Setup(cs => cs.Create(newCustomer));
            var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object

                );
            var result = (ObjectResult)customersController.CreateNewCustomer(newCustomer);
            result.Value.GetType().Should().Be(typeof(CustomerViewModel));
        }
// TEST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── VI ──────────
//   :::::: U P D A T E   C U S T O M E R   U S I N G   T H E   R I G H T   M O D E L   T H A T   W I L L   R E T U R N   A   2 0 0   S U C C E S S   C O D E : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

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
             var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object
                );

            var result = (StatusCodeResult)customersController.UpdateCustomer(1, updateCustomer);

            result.StatusCode.Should().Be(204);
        }
// TEST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── VII ──────────
//   :::::: U P D A T E   N O N   E X I S T I N G   C U S T O M E R   T H A T   W I L L   R E T U R N   A   4 0 4   S T A T U S   C O D E : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

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

            MockICustomerCommand.Setup(cmd => cmd.Update(cstmr, updateCustomer)).Returns(true);

            var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object

               );

            var result = (StatusCodeResult)customersController.UpdateCustomer(5, updateCustomer);
            result.StatusCode.Should().Be(404);

        }
// TEST
// ──────────────────────────────────────────────────────────────────────────────────────────────────────── VIII ──────────
//   :::::: D E L E T E   A N   E X I S T I N G   C U S T O M E R   T E S T : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//


        [Test]
        public void DeleteCustomer_Test()
        {
            MockICustomerCommand.Setup(cmd => cmd.Delete(cstmr));

            var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object
               );

            var result = (StatusCodeResult)customersController.DeleteCustomer(1);
            result.StatusCode.Should().Be(204);
        }
// TEST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── IX ──────────
//   :::::: D E L E T E   N O N   E X I S T I N G   C U S T O M E R   T H A T   W I L L   R E T U R N   A   4 0 4   S T A T U S   C O D E : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

        [Test]
        public void DeleteNonExistingEmployee_Test()
        {
            MockICustomerCommand.Setup(cmd => cmd.Delete(cstmr));

            var CustomersController = new CustomersController(
                MockICustomerQuery.Object,
                MockICustomerCommand.Object,
                MockICustomerFactory.Object,
                MockIResponseFactory.Object
                );

            var result = (StatusCodeResult)customersController.DeleteCustomer(2);
            result.StatusCode.Equals(404);
        }

    }
}