using NUnit.Framework;
using Smart_Accounting.Domain.Employe;


namespace Smart_Accounting.Domain.NUnitTest.Employee
{

    [TestFixture]
    public class EmployeesTest
    {
        private Employees employee;

        [OneTimeSetUp]
        public void emp()
        {
            employee = new Employees();
            employee.Id = 1;
            employee.FirstName = "ephrem";
            employee.LastName = "bayru";
<<<<<<< HEAD
            employee.AccountId = "123456";
=======
            employee.AccountId = 123456;
>>>>>>> 9ef68da30792e6e31c5afc6f3505b4fd316ec997
            employee.PhoneNo = "0920208549";
            employee.Email = "email";
            employee.Password = "123456";

        }

        [Test]
        public void EmployeeTest()
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
