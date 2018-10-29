using System;
using System.Net.Http;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Smart_Accounting.Application.Supplier.Factories;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.API.Controllers.Suppliers;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.API.NUnitTest.Supplier
{
    [TestFixture]
    public class SupplierControllerTEST
    {
        private Suppliers sply;
        private List<Suppliers> supplier;
        private NewSupplierModel newSupplier;
        private List<SupplierViewModel> supplierViews;
        private Mock<ISuppliersFactory> MockISupplierFactory;
        private Mock<ISupplierCommandes> MockISupplierCommand;
        private Mock<ISuppliersQuery> MockISupplierQuery;
        private Mock<IResponseFactory> MockIResponseFactory;
        private SuppliersController supplierController;
        private uint id;

        [OneTimeSetUp]
        public void TestSetup()
        {
            supplier = new List<Suppliers>();
            supplier.Add(new Suppliers()
            {
                Id = 1,
                FullName = "AppDiv",
                Email = "e@g.com",
                PhoneNo = "0920208549",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
            sply = new Suppliers()
            {
                Id = 1,
                Email = "e@g.com",
                PhoneNo = "0920208549",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            supplierViews = new List<SupplierViewModel>();
            supplierViews.Add(new SupplierViewModel()
            {
                id = 1,
            });
            MockISupplierCommand = new Mock<ISupplierCommandes>();
            MockISupplierFactory = new Mock<ISuppliersFactory>();
            MockISupplierQuery = new Mock<ISuppliersQuery>();
            MockIResponseFactory = new Mock<IResponseFactory>();
            MockISupplierFactory.Setup(factory => factory.CreateNewSupplier(newSupplier));
            MockISupplierQuery.Setup(query => query.GetById(id)).Returns(sply);

            var SuppplierController = new SuppliersController(
                MockISupplierQuery.Object,
                MockISupplierCommand.Object,
                MockISupplierFactory.Object,
                MockIResponseFactory.Object
            );
        }

        [Test]
        public void GetAllSuppliers_Test()
        {
            var result = (ObjectResult)supplierController.GetAllSuppliers();
            Assert.AreEqual(supplierViews, result);
            result.Value.GetType().Should().Be(typeof(SupplierViewModel));
            result.StatusCode.Equals(200);
            Assert.DoesNotThrow(() => { supplierController.Response.StatusCode = 500; });
        }

        [Test]
        public void GetSupplierById_Test()
        {
            var result = (ObjectResult)supplierController.GetSupplierById(id);
            Assert.AreEqual(supplierViews, result);
            result.StatusCode.Equals(200);
            Assert.DoesNotThrow(() => { supplierController.Response.StatusCode = 500; });
        }

        [Test]
        public void GetNonExistingSupplier_Test()
        {
            uint nonExistingSupplierId = 2;

            var result = (StatusCodeResult)supplierController.GetSupplierById(nonExistingSupplierId);
            result.StatusCode.Equals(200);
        }

        [Test]
        public void AddNewSupplier_Test()
        {
            newSupplier = new NewSupplierModel()
            {
                FullName = "AppDiv",
                Email = "e@g.com",
                Phone_No = "0920208549",
            };
            MockISupplierCommand.Setup(emp => emp.Create(sply));

            var SuppliersController = new SuppliersController(
                MockISupplierQuery.Object,
                MockISupplierCommand.Object,
                MockISupplierFactory.Object,
                MockIResponseFactory.Object
            );
            var result = (ObjectResult)supplierController.CreateNewSupplierr(newSupplier);

            result.StatusCode.Should().Be(201);
            result.Value.GetType().Should().Be(typeof(SupplierViewModel));
        }

        [Test]
        public void AddNewSupplierWithFalseModel_Test()
        {
            NewSupplierModel supplier = new NewSupplierModel()
            {
                FullName = "AppDiv",
                Email = "e@g.com",
            };
            newSupplier = new NewSupplierModel()
            {
                FullName = "AppDiv",
                Email = "e@g.com",
                Phone_No = "0920208549",
            };

            MockISupplierCommand.Setup(emply => emply.Create(sply));
            var SuppliersController = new SuppliersController(
                MockISupplierQuery.Object,
                MockISupplierCommand.Object,
                MockISupplierFactory.Object,
                MockIResponseFactory.Object
            );
            var result = (StatusCodeResult)supplierController.CreateNewSupplierr(supplier);
            result.StatusCode.Should().Be(422);
        }

        [Test]
        public void UpdateSupplier_Test()
        {
            UpdateSupplierModel updateSupplier = new UpdateSupplierModel()
            {
                FullName = "ephrem",
                Email = "e@g.com",
                Phone_No = "0920208549",
            };
            MockISupplierCommand.Setup(cmd => cmd.Update(sply, updateSupplier)).Returns(true);
            supplierController = new SuppliersController(
                MockISupplierQuery.Object,
                MockISupplierCommand.Object,
                MockISupplierFactory.Object,
                MockIResponseFactory.Object
            );

            var result = (StatusCodeResult)supplierController.UpdateSupplier(1, updateSupplier);

            result.StatusCode.Should().Be(204);
        }
        [Test]
        public void UpdateSupplierWithFalseModel_Test()
        {
            UpdateSupplierModel supplier = new UpdateSupplierModel()
            {
                id = 1,
                FullName = "ephrem",
                Email = "e@g.com",
                Phone_No = "0920208549",
            };

            UpdateSupplierModel updateSupplier = new UpdateSupplierModel()
            {

            };

            MockISupplierCommand.Setup(cmd => cmd.Update(sply, updateSupplier)).Returns(true);

            supplierController = new SuppliersController(
                MockISupplierQuery.Object,
                MockISupplierCommand.Object,
                MockISupplierFactory.Object,
                MockIResponseFactory.Object
            );

            var result = (StatusCodeResult)supplierController.UpdateSupplier(1, supplier);

            result.StatusCode.Should().Be(422);

        }

        [Test]
        public void DeleteSupplier_Test()
        {
            MockISupplierCommand.Setup(cmd => cmd.Delete(sply));

            supplierController = new SuppliersController(
               MockISupplierQuery.Object,
               MockISupplierCommand.Object,
               MockISupplierFactory.Object,
               MockIResponseFactory.Object
           );

            var result = (StatusCodeResult)supplierController.DeleteSuppler(1);
            result.StatusCode.Should().Be(204);
        }

        [Test]
        public void DeleteNonExistingSupplier_Test()
        {
            MockISupplierCommand.Setup(cmd => cmd.Delete(sply));

            supplierController = new SuppliersController(
               MockISupplierQuery.Object,
               MockISupplierCommand.Object,
               MockISupplierFactory.Object,
               MockIResponseFactory.Object
           );

            var result = (StatusCodeResult)supplierController.DeleteSuppler(2);
            result.StatusCode.Equals(404);
        }
    }

}
