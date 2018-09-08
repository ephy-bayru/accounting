/*
 * @CreateTime: Sep 5, 2018 12:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 4:24 PM
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
        private uint organizationId;
        private NewOrganizationModel newOrganization;
        private Organization organization;
        private OrganizationController organizationController;
        private Mock<IOrganizationCommands> MockIOrganizationCommand;
        private Mock<IOrganizationsQuery> MockIOrganizationQuerys;

        private Mock<IOrganizationFactory> MockIOrganizationFactories;

        [SetUp]
        public void Init () {

            organizationId = 1;
            organization = new Organization () {
                Id = 1,
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            organizationView = new OrganizationViewModel () {
                id = 1,
                name = "AppDiv",
                location = "A.A",
                tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            MockIOrganizationCommand = new Mock<IOrganizationCommands> ();
            MockIOrganizationQuerys = new Mock<IOrganizationsQuery> ();
            MockIOrganizationFactories = new Mock<IOrganizationFactory> ();

            MockIOrganizationQuerys.Setup (query => query.GetOrganizationById (organizationId)).Returns (organization);
            MockIOrganizationFactories.Setup (factory => factory.OrganizationView (organization)).Returns (organizationView);
        }

        [Test]
        public void GetOrganizationById () {

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = organizationController.GetOrganizationById (7);

            Assert.IsNotNull (result);

            //TODO : Test if the return type of GetOrganizationById is OrganizationViewModel
            //TODO : Test if the Http Header return type of GetOrganizationById is 200 ok Status Code
        }
        
        public void GetAllOrganizationsTest() {
            //TODO : Test GetAllOrganizations Controller Method
        }

        [Test]
        public void CreateNewOrganizationTest () {
            newOrganization = new NewOrganizationModel () {
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890"
            };

            MockIOrganizationCommand.Setup (cmd => cmd.CreateOrganization (newOrganization)).Returns (organizationView);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = organizationController.AddNewOrganization (newOrganization);

            Assert.IsNotNull (result);

            //TODO : Test if the return type of AddNewOrganization is OrganizationViewModel
            //TODO : Test if the Http Header return type of AddNewOrganization is 201 Create Status Code
            //  OrganizationViewModel view = result as OrganizationViewModel;

            //    Assert.That(view.Name, Is.EqualTo(organizationView.Name));

        }

        [Test]
        public void UpdateOrganizationTest () {
            UpdatedOrganizationModel updatedOrganization = new UpdatedOrganizationModel () {
                id = 1,
                name = "AppDiv Updated",
                location = "A.A",
                tin = "1234567890"

            };

            MockIOrganizationCommand.Setup (cmd => cmd.UpdateOrganization (organization, updatedOrganization)).Returns (true);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = organizationController.UpdateOrganization (1, updatedOrganization);

            Assert.IsNotNull (result);

            //TODO : Test if the return type of UpdateOrganization is 204 NoContent Status Code

        }

        [Test]
        public void DeleteOrganizationTest () {
            MockIOrganizationCommand.Setup (cmd => cmd.deleteOrganization (organization)).Returns (true);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = organizationController.DeleteOrganization (1);
            Assert.IsNotNull (result);
            //TODO : Test if the return type of DeleteOrganization is 204 NoContent Status Code

        }

    }
}