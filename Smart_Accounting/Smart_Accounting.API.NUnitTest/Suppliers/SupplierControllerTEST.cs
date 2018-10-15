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
        private Mock<SuppliersController> MockISupplierCommand;
        private Mock<ISuppliersFactory> MockISupplierFactory;
        private Mock<ISuppliersQuery> MockISupplierQuery;
        private Mock<IResponseFactory> MockIResponseFactory;
        private SuppliersController supplierController;
        private uint id;

    }
    
}
