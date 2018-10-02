using NUnit.Framework;
using Smart_Accounting.Domain.Employe;


namespace Smart_Accounting.Domain.NUnitTest.Employee
{

    [TestFixture]
    public class EmployeessTest
    {
        private Employees employee;

        [OneTimeSetUp]
        public void Cust()
        {
            employee = new Employees();
            employee.Id = 1;
            employee.FirstName = "ephrem";
            employee.LastName = "bayru";
            employee.AccountId = "123456";
            employee.PhoneNo = "0920208549";
            employee.Email = "email";
            employee.Password = "123456";

        }

        [Test]
        public void CustomerTest()
        {
            Assert.That(employee.Id, Is.EqualTo(1));
            Assert.That(employee.FirstName, Is.EqualTo("ephrem"));
            Assert.That(employee.LastName, Is.EqualTo("bayru"));
            Assert.That(employee.Email, Is.EqualTo("email"));
            Assert.That(employee.AccountId, Is.EqualTo("123456"));
            Assert.That(employee.PhoneNo, Is.EqualTo("0920208549"));
            Assert.That(employee.Password, Is.EqualTo("123456"));

        }

    }
}
