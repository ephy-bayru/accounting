using NUnit.Framework;
using Smart_Accounting.Domain.Supplier;


namespace Smart_Accounting.Domain.NUnitTest.Supplier
{

    [TestFixture]
    public class SuppliersTest
    {
        private Suppliers suppliers;

        [OneTimeSetUp]
        public void Cust()
        {
            suppliers = new Suppliers();
            suppliers.Id = 1;
            suppliers.FullName = "Dventus";
            suppliers.AccountId = "4458914336";
            suppliers.PhoneNo = "0913568265";
            suppliers.Email = "d@gmail.com";
            suppliers.Country = "Ethiopia";
            suppliers.City = "Adis";
            suppliers.SubCity = "Bole";
            suppliers.HouseNo = "8976";
            suppliers.PostalCode = "4638";

        }
        [Test]
        public void SupplierTest()
        {
            Assert.That(suppliers.Id, Is.EqualTo(1));
            Assert.That(suppliers.FullName, Is.EqualTo("Dventus"));
            Assert.That(suppliers.AccountId, Is.EqualTo("4458914336"));
            Assert.That(suppliers.PhoneNo, Is.EqualTo("0913568265"));
            Assert.That(suppliers.Email, Is.EqualTo("d@gmail.com"));
            Assert.That(suppliers.Country, Is.EqualTo("Ethiopia"));
            Assert.That(suppliers.City, Is.EqualTo("Adis"));
            Assert.That(suppliers.SubCity, Is.EqualTo("Bole"));
            Assert.That(suppliers.HouseNo, Is.EqualTo("8976"));
            Assert.That(suppliers.PostalCode, Is.EqualTo("4638"));

        }

    }
}
