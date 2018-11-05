/*
 * @CreateTime: Oct 3, 2018 9:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 9:39 AM
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
using Smart_Accounting.Application.Employee.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.API.Controllers.Employee;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.API.NUnitTest.Employee {
    [TestFixture]
    public class EmployeeControllerTEST {
        private Employees emply;
        private List<Employees> employee;
        private NewEmployeeModel newEmployee;
        private List<EmployeeViewModel> employeeView;
        private EmployeesController EmployeesController;
        private Mock<IEmployeeCommands> MockIEmployeeCommand;
        private Mock<IEmployeeFactory> MockIEmployeeFactory;
        private Mock<IEmployeesQueries> MockIEmployeeQuery;
        private Mock<IResponseFactory> MockIResponseFactory;
        private EmployeesController employeeController;
        private Mock<HttpContext> MockHttpContext;
        private uint id;
        //
        // ────────────────────────────────────────────────────────────────────────────────────────────────────────  ──────────
        //   :::::: O N E   T I M E   S E T U P   F O R   E M P L O Y E E   T E S T : :  :   :    :     :        :          :
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        //
        [OneTimeSetUp]
        public void TestSetup () {

            employee = new List<Employees> ();
            employee.Add (new Employees () {
                Id = 1,
                    FirstName = "ephrem",
                    LastName = "bayru",
                    Email = "e@g.com",
                    PhoneNo = "0920208549",
                    Gender = "male",
                    Password = "123456",
                    BirthDate = DateTime.Now,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
            });
            emply = new Employees () {
                Id = 1,
                FirstName = "ephrem",
                LastName = "bayru",
                Email = "e@g.com",
                PhoneNo = "0920208549",
                Gender = "male",
                Password = "123456",
                BirthDate = DateTime.Now,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            employeeView = new List<EmployeeViewModel> ();
            employeeView.Add (new EmployeeViewModel () {
                id = 1,
                    First_Name = "ephrem",
                    Last_Name = "bayru",
                    Email = "e@g.com",
                    Phone_No = "0920208549",
                    Gender = "male",
                    Account_Number = "123456",
                    Birth_Date = DateTime.Now,
                    Date_Created = DateTime.Now,
                    Date_Updated = DateTime.Now
            });
            var MockHttpContext = new Mock<HttpContext> ();
            MockIEmployeeCommand = new Mock<IEmployeeCommands> ();
            MockIEmployeeFactory = new Mock<IEmployeeFactory> ();
            MockIEmployeeQuery = new Mock<IEmployeesQueries> ();
            MockIResponseFactory = new Mock<IResponseFactory> ();
            // MockLoggerFactory = new Mock<ILoggerFactory>();
            // MockHttpContext = new Mock<HttpContext>();
            MockIEmployeeFactory.Setup (factory => factory.createEmployeeView (employee)).Returns (employeeView);
            MockIEmployeeQuery.Setup (query => query.GetById (id)).Returns (emply);

            var EmployeesController = new EmployeesController (
                MockIEmployeeQuery.Object,
                MockIEmployeeCommand.Object,
                MockIEmployeeFactory.Object,
                MockIResponseFactory.Object
            );
            EmployeesController.ControllerContext = new ControllerContext () {
                HttpContext = MockHttpContext.Object
            };
        }
        // TEST
        // ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── I ──────────
        //   :::::: G E T   A L L   E M P L O Y E E S   T E S T   T H A T   W I L L   R E T U R N   2 0 0   S T A T U S   C O D E : :  :   :    :     :        :          :
        // ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 200

        [Test]
        public void GetAllEmployees_Test () {
            var result = (ObjectResult) EmployeesController.GetAllEmployees ();
            Assert.AreEqual (employeeView, result);
            result.Value.GetType ().Should ().Be (typeof (EmployeeViewModel));
            result.StatusCode.Equals (200);
            Assert.DoesNotThrow (() => { EmployeesController.Response.StatusCode = 500; });
        }
        // TEST
        // ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── II ──────────
        //   :::::: G E T   A   S I N G L E   E M P L O Y E E   U S I N G   T H E I R   I D   T E S T : :  :   :    :     :        :          :
        // ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 200

        [Test]
        public void GetEmployeesById_Test () {
            var result = (ObjectResult) EmployeesController.GetEmployeeById (id);
            Assert.AreEqual (employeeView, result);
            result.StatusCode.Equals (200);
            Assert.DoesNotThrow (() => { EmployeesController.Response.StatusCode = 500; });
        }
        // TEST
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────── III ──────────
        //   :::::: G E T   A   N O N   E X I S T I N G   E M P L O Y E E   T E S T : :  :   :    :     :        :          :
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 404
        [Test]
        public void GetNonExistingEmployee_Test () {
            uint nonExistingEmployeenId = 2;

            var result = (StatusCodeResult) EmployeesController.GetEmployeeById (nonExistingEmployeenId);
            result.StatusCode.Equals (200);
        }
        // TEST
        // ────────────────────────────────────────────────────────────────────────────────────── IV ──────────
        //   :::::: A D D    N E W   E M P L O Y E E   T E S T : :  :   :    :     :        :          :
        // ────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 200
        [Test]
        public void AddNewEmployee_Test () {
            newEmployee = new NewEmployeeModel () {
                First_Name = "ephrem",
                Last_Name = "bayru",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Gender = "male",
                Password = "123456",
                Account_Id = "123456",
                Birth_Date = DateTime.Now,
            };
            MockIEmployeeCommand.Setup (emp => emp.Create (emply));

            EmployeesController = new EmployeesController (
                MockIEmployeeQuery.Object,
                MockIEmployeeCommand.Object,
                MockIEmployeeFactory.Object,
                MockIResponseFactory.Object
            );
            var result = (ObjectResult) EmployeesController.CreateNewEmployee (emply);

            result.StatusCode.Should ().Be (201);
            result.Value.GetType ().Should ().Be (typeof (EmployeeViewModel));
        }
        // TEST
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────── V ──────────
        //   :::::: A D D   N E W   E M P L O Y E E   W I T H   F A L S E   M O D E L   T E S T : :  :   :    :     :        :          :
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 422

        [Test]
        public void AddNewEmployeeWithFalseModel_Test () {
            NewEmployeeModel employee = new NewEmployeeModel () {
                First_Name = "ephrem",
                Email = "e@g.com",
                Gender = "male",
            };
            newEmployee = new NewEmployeeModel () {
                First_Name = "ephrem",
                Last_Name = "bayru",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Gender = "male",
                Password = "123456",
                Birth_Date = DateTime.Now,
            };

            MockIEmployeeCommand.Setup (empl => empl.Create (emply));
            EmployeesController = new EmployeesController (
                MockIEmployeeQuery.Object,
                MockIEmployeeCommand.Object,
                MockIEmployeeFactory.Object,
                MockIResponseFactory.Object
            );
            var result = (StatusCodeResult) EmployeesController.CreateNewEmployee (emply);
            result.StatusCode.Should ().Be (422);
        }
        // TEST
        // ────────────────────────────────────────────────────────────────────────────────────────────────────── VI ──────────
        //   :::::: U D A T E   A N   E X I S T I N G   E M P L O Y E E   T E S T : :  :   :    :     :        :          :
        // ────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 200

        [Test]
        public void UpdateEmployee_Test () {
            UpdatedEmployeeDto updateEmployee = new UpdatedEmployeeDto () {
                First_Name = "ephrem",
                Last_Name = "bayru",
                Email = "e@g.com",
                Phone_No = "0920208549",
                Gender = "male",
                Password = "123456",
                Account_Id = "123456",
                Birth_Date = DateTime.Now,
            };
            MockIEmployeeCommand.Setup (cmd => cmd.Update (emply, updateEmployee));
            EmployeesController = new EmployeesController (
                MockIEmployeeQuery.Object,
                MockIEmployeeCommand.Object,
                MockIEmployeeFactory.Object,
                MockIResponseFactory.Object
            );

            var result = (StatusCodeResult) EmployeesController.UpdateEmployee (1, updateEmployee);

            result.StatusCode.Should ().Be (204);
        }

        //  TEST
        // ──────────────────────────────────────────────────────────────────────────────── VII ──────────
        //   :::::: D E L E T E   E M P L O Y E E   T E S T : :  :   :    :     :        :          :
        // ──────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 200

        [Test]
        public void DeleteEmployee_Test () {
            MockIEmployeeCommand.Setup (cmd => cmd.Delete (emply));

            EmployeesController = new EmployeesController (
                MockIEmployeeQuery.Object,
                MockIEmployeeCommand.Object,
                MockIEmployeeFactory.Object,
                MockIResponseFactory.Object
            );

            var result = (StatusCodeResult) EmployeesController.DeleteEmployee (1);
            result.StatusCode.Should ().Be (204);
        }
        // TEST
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────── VIII ──────────
        //   :::::: D E L E T E   N O N   E X I S T N G   E M P L O Y E E   T E S T : :  :   :    :     :        :          :
        // ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        // RETURNS 404

        [Test]
        public void DeleteNonExistingEmployee_Test () {
            MockIEmployeeCommand.Setup (cmd => cmd.Delete (emply));

            EmployeesController = new EmployeesController (
                MockIEmployeeQuery.Object,
                MockIEmployeeCommand.Object,
                MockIEmployeeFactory.Object,
                MockIResponseFactory.Object
            );

            var result = (StatusCodeResult) EmployeesController.DeleteEmployee (2);
            result.StatusCode.Equals (404);
        }
    }
}