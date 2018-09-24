
using System;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Factories;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.API.Controllers.Employee;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Domain.Employe;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using NUnit.Framework;
using Moq;

namespace Smart_Accounting.API.NUnitTest.Employees
{
    public class EmployeeControllerTEST
    {
        private EmployeesController EmployeesController;
        private Mock<IEmployeeCommands> MockIEmployeeCommand;
        private Mock<IEmployeeFactory> MockIEmployeeFactory;
        private Mock<IEmployeesQueries> MockIEmployeeQuery;
        private Mock<IResponseFactory> MockIResponseFactory;
        private Mock<HttpContext> MockHttpContext;

    }
}