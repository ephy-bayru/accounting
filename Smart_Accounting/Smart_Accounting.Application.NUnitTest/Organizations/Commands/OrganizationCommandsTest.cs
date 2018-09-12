/*
 * @CreateTime: Sep 4, 2018 4:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 5:25 PM
 * @Description: TEST class for organization command factory
 */

using System;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Organizations.Commands;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.NUnitTest.Organizations.Commands {

    [TestFixture]
    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    public class OrganizationCommandsTest {
        private OrganizationViewModel organizationView;
        private NewOrganizationModel validOrganization;
        private Organization organization;

        private Mock<IOrganizationFactory> MockIOrganizationFactory;

        private Mock<IAccountingDatabaseService> MockIAccountingDatabase;

        /// <summary>
        /// Create the basic workbench for OrganizationCommand class testn
        /// </summary>
        [SetUp]
        public void Init () {

            // organization object used for mocking organization record from the database
            organization = new Organization () {
                Id = 1,
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)

            };

            // Organization Model Used to Represent new organization thats sent for creation
            validOrganization = new NewOrganizationModel () {
                Name = "AppDiv new",
                Location = "A.A",
                Tin = "1029384756"
            };
            
            // organization model used to represent data sent to the user for presentation
            organizationView = new OrganizationViewModel () {
                id = 1,
                name = "AppDiv view",
                location = "A.A",
                tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            //Create Mock Obbject for IOrganizationFactory and IAccountingDatabaseService for injection
            MockIOrganizationFactory = new Mock<IOrganizationFactory> ();
            MockIAccountingDatabase = new Mock<IAccountingDatabaseService> ();

            //set up a mock functions for each function required by the class
            MockIOrganizationFactory.Setup (orgFac => orgFac.OrganizationForCreation (validOrganization)).Returns (organization);
            MockIOrganizationFactory.Setup (orgFac => orgFac.OrganizationView (organization)).Returns (organizationView);
            MockIAccountingDatabase.Setup (database => database.Organization.Add (organization));
            MockIAccountingDatabase.Setup (database => database.Organization.Update (organization));
            MockIAccountingDatabase.Setup (database => database.Save ());

        }

        /// <summary>
        /// Test function for OrganizationCommand.Create function
        /// </summary>
        [Test]
        public void CreateValidOrganizationTEST () {

            //create organization command class by injecting all of its dependencies
            var organizationCommand = new OrganizationCommand (MockIOrganizationFactory.Object, MockIAccountingDatabase.Object);

            //execute createOrganization command passing sample organization object
            var result = organizationCommand.CreateOrganization (validOrganization);

            //check if the action created new organization instance and retuned view model of the instancs
            Assert.That (result.name, Is.EqualTo (organizationView.name));

        }

        [Test]
        public void CreateInvalidOrganizationTEST () {

            NewOrganizationModel invalidOrganization = new NewOrganizationModel () {
                Name = "AppDiv new",
                Location = "A.A"
            };
            //create organization command class by injecting all of its dependencies
            var organizationCommand = new OrganizationCommand (MockIOrganizationFactory.Object, MockIAccountingDatabase.Object);

            //execute createOrganization command passing sample organization object
            var result = organizationCommand.CreateOrganization (invalidOrganization);

            //check if the action created new organization instance and retuned view model of the instancs
            Assert.That (result == null);

        }

        /// <summary>
        /// Test Function for Organization.Updateorganization()
        /// </summary>
        [Test]
        public void validUpdateOrganizationTEST () {
            // create UpdatedOrganizationModel type object
            UpdatedOrganizationModel validUpdatedOrganization = new UpdatedOrganizationModel () {
                id = 1,
                name = "AppDiv updated",
                location = "A.A",
                tin = "1029384756"
            };

            //create organization object
            Organization updated_org = new Organization () {
                Id = 1,
                Name = "AppDiv Updated",
                Location = "A.A",
                Tin = "1029384756",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)

            };

            //Mock organization factory class to provide the required functionalities
            MockIOrganizationFactory.Setup (orgFac => orgFac.OrganizationForUpdate (organization, validUpdatedOrganization)).Returns (updated_org);

            //Mock organization command to provide the required functionality by injecting mock dependencies
            var organizationCommand = new OrganizationCommand (MockIOrganizationFactory.Object, MockIAccountingDatabase.Object);

            //ACT execute the updateOrganization command 
            var result = organizationCommand.UpdateOrganization (organization, validUpdatedOrganization);

            //Test if the returned value is true
            Assert.That (Is.Equals (result, true));
        }

        /// <summary>
        /// Delete Organization Functionality Testing  
        /// </summary>
        [Test]
        public void DeleteOrganizationTEST () {

            //Mock the Data base remove function
            MockIAccountingDatabase.Setup (database => database.Organization.Remove (organization));
            // CreateOrganizationTEST organization  command class by passing all of it dependencies as a mock
            var organizationCommand = new OrganizationCommand (MockIOrganizationFactory.Object, MockIAccountingDatabase.Object);

            //Act: Execute the delete functionality in the organization command class
            var result = organizationCommand.deleteOrganization (organization);

            //checked if the organization was deleted successfully
            Assert.That (result, Is.EqualTo (true));

        }
    }
}