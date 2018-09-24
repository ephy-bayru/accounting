/*
 * @CreateTime: Sep 4, 2018 11:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 24, 2018 9:23 AM
 * @Description: Organization Factory Test 
 */
using System;
using NUnit.Framework;
using Smart_Accounting.Application.Organizations.Factory;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.NUnitTest.Organizations.Factories {

    [Author ("Mikael Araya", "Mikaelaraya12@gmail.com")]
    [TestFixture]
    public class OrganizationFactoryTest {

        private NewOrganizationModel NEW_ORGANIZATION;
        private OrganizationFactory organizationFactory;
        private UpdatedOrganizationModel updated_ORGANIZATION;

        [SetUp]
        public void init () {
            // innitialize new organization model 
            NEW_ORGANIZATION = new NewOrganizationModel ();
            NEW_ORGANIZATION.Name = "AppDiv";
            NEW_ORGANIZATION.Location = "A.A";
            NEW_ORGANIZATION.Tin = "9292929292";

            //initialize updated organization model
            updated_ORGANIZATION = new UpdatedOrganizationModel ();
            updated_ORGANIZATION.Name = "updated  AppDiv";
            updated_ORGANIZATION.Location = "updated A.A";
            updated_ORGANIZATION.Tin = "1029384756";

            organizationFactory = new OrganizationFactory ();
        }

        [Test]
        public void OrganizationForCreationTEST () {

            Organization organization = organizationFactory.OrganizationForCreation (NEW_ORGANIZATION);

            Assert.That (organization.Id, Is.EqualTo (0));
            Assert.That (organization.Name, Is.EqualTo (NEW_ORGANIZATION.Name));
            Assert.That (organization.Location, Is.EqualTo (NEW_ORGANIZATION.Location));
            Assert.That (organization.Tin, Is.EqualTo (NEW_ORGANIZATION.Tin));
            Assert.That (organization.DateAdded.ToString (), Is.EqualTo (DateTime.Now.ToString ()));
            Assert.That (organization.DateUpdated.ToString (), Is.EqualTo (DateTime.Now.ToString ()));
        }
        
        /// <summary>
        /// Check if OrganizationForUpdate returns the the updated organization information given
        /// new organizer information
        /// </summary>
        [Test]
        public void OrganizationForUpdateTEST () {
            //represents organization from the database
            Organization old_organization = new Organization () {
                Id = 1,
                Name = "AppDiv Test",
                Location = "A.A",
                Tin = "1029384756",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            Organization result = organizationFactory.OrganizationForUpdate (old_organization, updated_ORGANIZATION);

            Assert.That (result.Id, Is.EqualTo (old_organization.Id));
            Assert.That (result.Name, Is.EqualTo (updated_ORGANIZATION.Name));
            Assert.That (result.Location, Is.EqualTo (updated_ORGANIZATION.Location));
            Assert.That (result.Tin, Is.EqualTo (updated_ORGANIZATION.Tin));
            Assert.That (Is.Equals (result.DateAdded.ToString (), DateTime.Now.ToString ()));
            Assert.That (Is.Equals (result.DateUpdated.ToString (), DateTime.Now.AddDays (1).ToString ()));

        }


        /// <summary>
        /// Test if OrganizationFirView method returns Correct OrganizationView Model
        /// Passed Organizer Information
        /// </summary>
        [Test]
        public void OrganizationForViewTest () {
            //represents organization from the database
            Organization organization = new Organization () {
                Id = 1,
                Name = "AppDiv Test",
                Location = "A.A",
                Tin = "1029384756",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now.AddDays (1)
            };

            OrganizationViewModel view = organizationFactory.OrganizationView (organization);

            Assert.That (view.id, Is.EqualTo (organization.Id));
            Assert.That (view.name, Is.EqualTo (organization.Name));
            Assert.That (view.location, Is.EqualTo (organization.Location));
            Assert.That (view.tin, Is.EqualTo (organization.Tin));
            Assert.That (view.DateAdded.ToString (), Is.EqualTo (DateTime.Now.ToString()));
            Assert.That (view.DateUpdated.ToString (), Is.EqualTo (DateTime.Now.AddDays (1).ToString ()));

        }
    }
}