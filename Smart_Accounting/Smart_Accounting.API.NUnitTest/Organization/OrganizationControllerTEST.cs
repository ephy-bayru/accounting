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
using FluentAssertions;
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
        private uint existingOrganizationId;
        private NewOrganizationModel newOrganization;
        private Organization organization;
        private OrganizationController organizationController;
        private Mock<IOrganizationCommands> MockIOrganizationCommand;
        private Mock<IOrganizationsQuery> MockIOrganizationQuerys;

        private Mock<IOrganizationFactory> MockIOrganizationFactories;


        /// <summary>
        /// Setting up globally used configurations for organization api controller
        /// </summary>
        [SetUp]
        public void Init () {

            existingOrganizationId = 1;
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

            MockIOrganizationQuerys.Setup (query => query.GetOrganizationById (existingOrganizationId)).Returns (organization);
            MockIOrganizationFactories.Setup (factory => factory.OrganizationView (organization)).Returns (organizationView);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

        }

        /// <summary>
        /// Test GetOrganizationById for Existing organization record by its Id
        /// </summary>
        [Test]
        public void GetOrganizationById_Existing_Organization_TEST () {

            var result = (ObjectResult) organizationController.GetOrganizationById (existingOrganizationId);

            result.StatusCode.Should ().Be (200);
            result.Value.GetType ().Should ().Be (typeof (OrganizationViewModel));

        }

        /// <summary>
        /// Tests GetOrganizationById For Non existing organization Id
        /// </summary>
        [Test]
        public void GetOrganizationById_Non_Existing_Organization_Test () {
            uint nonExistingOrganizationId = 2;

            var result = (StatusCodeResult) organizationController.GetOrganizationById (nonExistingOrganizationId);

            result.StatusCode.Should ().Be (404);
        }


        /// <summary>
        /// Tests createOrganization() for the successful creation of new organization 
        /// </summary>
        [Test]
        public void CreateNewOrganization_201_Successful_TEST () {
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

            var result = (ObjectResult) organizationController.AddNewOrganization (newOrganization);

            result.StatusCode.Should ().Be (201);
            result.Value.GetType ().Should ().Be (typeof (OrganizationViewModel));

        }

        /// <summary>
        /// Tests CreateOrganization() for Failure result when passed invalid organization data
        /// </summary>
        [Test]
        public void CreateNewOrganization_422_Failed_TEST () {
            NewOrganizationModel invalidOrganization = new NewOrganizationModel () {

                Tin = "1234567890"
            };
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

            var result = (StatusCodeResult) organizationController.AddNewOrganization (invalidOrganization);

            result.StatusCode.Should ().Be (422);

            result.StatusCode.Should ().Be (422);

        }

        /// <summary>
        /// Test UpdateOrganization() controller function for a successful update completion
        /// by testing the return type
        /// </summary>
        [Test]
        public void UpdateOrganization_204_Successful_Test () {
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

            var result = (StatusCodeResult) organizationController.UpdateOrganization (1, updatedOrganization);

            result.StatusCode.Should ().Be (204);

        }

        /// <summary>
        /// Tests UpdateOrganization() controller for the  response when presented with un existing organization Id
        /// to return 404 or fail
        /// </summary>
        [Test]
        public void UpdateOrganization_404_NoFound_Test () {
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

            var result = (StatusCodeResult) organizationController.UpdateOrganization (2, updatedOrganization);

            result.StatusCode.Should ().Be (404);

        }

        /// <summary>
        /// Tests UpdateOrganization for the scenario when the passed data is missing required fields 
        /// by testing if it returns 422 unprocessable entity result
        /// </summary>
        [Test]
        public void UpdateOrganization_422_Unprocessable_Entity_Test () {
            UpdatedOrganizationModel updatedOrganization = new UpdatedOrganizationModel () {
                id = 1,
                name = "AppDiv Updated",
                location = "A.A",
                tin = "1234567890"

            };

            UpdatedOrganizationModel invalidOrganization = new UpdatedOrganizationModel () {

                tin = "1234567890"
            };

            MockIOrganizationCommand.Setup (cmd => cmd.UpdateOrganization (organization, updatedOrganization)).Returns (true);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = (StatusCodeResult) organizationController.UpdateOrganization (1, invalidOrganization);

            result.StatusCode.Should ().Be (422);

        }

        /// <summary>
        /// Test for deleteOrganizationBy controller function for successful deletion of organization data
        /// by checking if the status code is 204
        /// </summary>
        [Test]
        public void DeleteOrganization_204_Successful_Test () {
            MockIOrganizationCommand.Setup (cmd => cmd.deleteOrganization (organization)).Returns (true);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = (StatusCodeResult) organizationController.DeleteOrganization (1);
            result.StatusCode.Should ().Be (204);

        }
        /// <summary>
        /// tests deleteOrganization for response when presented with non existing organization Id
        /// by checking if it returns 404
        /// </summary>
        [Test]
        public void DeleteOrganization_404_NotFound_Test () {
            MockIOrganizationCommand.Setup (cmd => cmd.deleteOrganization (organization)).Returns (true);

            organizationController = new OrganizationController (
                MockIOrganizationCommand.Object,
                MockIOrganizationQuerys.Object,
                MockIOrganizationFactories.Object
            );

            var result = (StatusCodeResult) organizationController.DeleteOrganization (4);
            result.StatusCode.Should ().Be (404);

        }

    }
}