using NUnit.Framework;
using Smart_Accounting.Domain.Customers;


namespace Smart_Accounting.Domain.NUnitTest.Customers
{

    [TestFixture]
    public class CustomersTest
    {
        private Customer customer;

        [OneTimeSetUp]
        public void Cust()
        {
            customer = new Customer();
            customer.Id = 1;
            customer.FullName = "Microsoft";
<<<<<<< HEAD
            customer.AccountId = "123456";
=======
            customer.AccountId = 123456;
>>>>>>> 9ef68da30792e6e31c5afc6f3505b4fd316ec997
            customer.PhoneNo = "0920208549";
            customer.Email = "email";
            customer.Country = "Ethiopia";
            customer.City = "Dessie";
            customer.SubCity = "gtz";
            customer.HouseNo = "123456";
            customer.PostalCode = "123456";

        }
        [Test]
        public void CustomerTest()
        {
            Assert.That(customer.Id, Is.EqualTo(1));
            Assert.That(customer.FullName, Is.EqualTo("Microsoft"));
            Assert.That(customer.AccountId, Is.EqualTo("123456"));
            Assert.That(customer.PhoneNo, Is.EqualTo("0920208549"));
            Assert.That(customer.Email, Is.EqualTo("email"));
            Assert.That(customer.Country, Is.EqualTo("Ethiopia"));
            Assert.That(customer.City, Is.EqualTo("Dessie"));
            Assert.That(customer.SubCity, Is.EqualTo("gtz"));
            Assert.That(customer.HouseNo, Is.EqualTo("123456"));
            Assert.That(customer.PostalCode, Is.EqualTo("123456"));

        }

    }
}
