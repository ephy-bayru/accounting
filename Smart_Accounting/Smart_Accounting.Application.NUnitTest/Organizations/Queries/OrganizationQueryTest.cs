/*
 * @CreateTime: Sep 5, 2018 11:01 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 3:19 PM
 * @Description: Test Class for Organization.OrganizationQuery Class
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Application.Organizations.Queries;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.NUnitTest.Organizations.Queries {
    [TestFixture]
    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    public class OrganizationQueryTest {

        private IList<Organization> organizationList;
        private Organization organization;

        private Mock<IAccountingDatabaseService> MockIAccountingDatabaseService;
        private Mock<IOrganizationFactory> MockIOrganizationFactory;

        private OrganizationViewModel organizationView;
        [SetUp] //Initialize Basic Data structure model for organization
        public void Init () {
            organization = new Organization ();
            Organization org = new Organization () {
                Id = 1,
                Name = "AppDiv",
                Location = "A.A",
                Tin = "1234567890",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1),
            };
            organizationList = new List<Organization> ();

            organizationList.Add (org);
            MockIAccountingDatabaseService = new Mock<IAccountingDatabaseService> ();
            MockIOrganizationFactory = new Mock<IOrganizationFactory> ();

            uint i = 1;
            MockIAccountingDatabaseService.Setup (database => database.Organization.Find (i)).Returns (organization);
            //   MockIAccountingDatabaseService.Setup (database => database.Organization.ToList ()).Returns (organizationList);

        }

        [Test]
        public void GetOrganizationByIdTEST () {

            OrganizationQuery organizationQuery = new OrganizationQuery (MockIAccountingDatabaseService.Object, MockIOrganizationFactory.Object);

            var result = organizationQuery.GetOrganizationById (1);

            Assert.That (result.Name, Is.EqualTo (organization.Name));
        }

        //TODO Implement GetAllOrganizations Test Method
        /*
                     public void GetAllOrganizations () {
                    OrganizationQuery organizationQuery = new OrganizationQuery (MockIAccountingDatabaseService.Object, MockIOrganizationFactory.Object);

                }
                */
    }
}