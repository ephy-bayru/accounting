/*
 * @CreateTime: Sep 5, 2018 12:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 3:17 PM
 * @Description: Organization RESTfull API Controller
 */
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.API.Controllers.Organizations;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.API.NUnitTest.Organizatios {

    [TestFixture]
    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    public class OrganizationControllerTEST {

        private OrganizationViewModel organizationView;

        private Organization organization;
        public OrganizationController organizationController;
        private Mock<IOrganizationCommands> MockIOrganizationCommand;
        private Mock<IOrganizationsQuery> MockIOrganizationQuerys;

        private Mock<IOrganizationFactory> MockIOrganizationFactories;

        [SetUp]
        public void Init () {
            organization = new Organization () {
                Id = 1,
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            organizationView = new OrganizationViewModel () {
                Id = 1,
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };
        }

        [Test]
        public void GetOrganizationById () {
            MockIOrganizationCommand = new Mock<IOrganizationCommands> ();
            MockIOrganizationQuerys = new Mock<IOrganizationsQuery> ();
            MockIOrganizationFactories = new Mock<IOrganizationFactory> ();
            uint organizationId = 1;
            organization = new Organization () {
                Id = 1,
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            MockIOrganizationQuerys.Setup (query => query.GetOrganizationById (organizationId)).Returns (organization);
            MockIOrganizationFactories.Setup (factory => factory.OrganizationView (organization)).Returns (organizationView);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = organizationController.GetOrganizationById (organizationId);
            Assert.IsNotNull (result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull (result);

        }

    }
}