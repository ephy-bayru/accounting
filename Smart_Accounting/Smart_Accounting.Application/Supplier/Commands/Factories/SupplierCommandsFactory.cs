using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Commands.Factories
{
    public class SupplierCommandsFactory : ISupplierCommandsFactory
    {
        public Suppliers NewSupplier(NewSupplierModel newSupplier)
        {
            var supplier = new Suppliers();

            supplier.FullName = newSupplier.FullName;
            supplier.AccountId = newSupplier.AccountId;
            supplier.Email = newSupplier.Email;
            supplier.PhoneNo = newSupplier.Phone_No;
            supplier.Country = newSupplier.Country;
            supplier.City = newSupplier.City;
            supplier.SubCity = newSupplier.SubCity;
            supplier.HouseNo = newSupplier.HouseNo;
            supplier.PostalCode = newSupplier.PostalCode;

            return supplier;
        }

        public SupplierViewModel SupplierView(Suppliers suppliers)
        {
            var supplier = new SupplierViewModel();

            supplier.id = supplier.id;
            supplier.FullName = supplier.FullName;
            supplier.AccountId = supplier.AccountId;
            supplier.Email = supplier.Email;
            supplier.PhoneNo = supplier.PhoneNo;
            supplier.Country = supplier.Country;
            supplier.City = supplier.City;
            supplier.SubCity = supplier.SubCity;
            supplier.PostalCode = supplier.PostalCode;

            return supplier;

        }

        public Suppliers UpdateSupplier(Suppliers currentSupplier, UpdateSupplierModel updateSupplier)
        {
            currentSupplier.FullName = currentSupplier.FullName;
            currentSupplier.AccountId = currentSupplier.AccountId;
            currentSupplier.Email = currentSupplier.Email;
            currentSupplier.PhoneNo = currentSupplier.PhoneNo;
            currentSupplier.Country = currentSupplier.Country;
            currentSupplier.City = currentSupplier.City;
            currentSupplier.SubCity = currentSupplier.SubCity;
            currentSupplier.HouseNo = currentSupplier.HouseNo;
            currentSupplier.PostalCode = currentSupplier.PostalCode;

            return currentSupplier;
        }

        public Suppliers UpdateSuppliers(Suppliers supplier, UpdateSupplierModel updateSupplier)
        {
            throw new System.NotImplementedException();
        }
    }
}