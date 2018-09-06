/*
 * @CreateTime: Sep 3, 2018 2:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 12:24 PM
 * @Description: Organization Database Entity Model 
 */
using NUnit.Framework;
using Smart_Accounting.Domain.Oranizations;


namespace Smart_Accounting.Domain.NUnitTest.Organizations {
    
        [Author("Mikael Araya", "MikaelAraya12@gmail.com")]
        [TestFixture]
    public class OrganizationsTest {

        private Organization organization;

        [SetUp]  //Initialize Basic Organization Data
        public void Init() {
            organization = new Organization();
            organization.Id = 1;
            organization.Name = "AppDiv";
            organization.Location = "A.A";
            organization.Tin = "0922883366";                
        }

        [Test] //Test If All Values Initialized Coreectly
        public void OrganizationInitializationTEST() {
            
            Assert.That(organization.Id, Is.EqualTo(1));
            Assert.That(organization.Name, Is.EqualTo("AppDiv"));
            Assert.That(organization.Location, Is.EqualTo("A.A"));
            Assert.That(organization.Tin, Is.EqualTo("0922883366") );
        }


    }
}