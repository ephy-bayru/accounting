using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Commands.Factories
{
    public class SupplierCommandsFactory : ISupplierCommandsFactory
    {
        public Suppliers NewSupplier(Suppliers newSupplier)
        {
            var supplier = new Suppliers();

            supplier.FullName = newSupplier.FullName;
            supplier.Email = newSupplier.Email;
            supplier.PhoneNo = newSupplier.PhoneNo;
            supplier.Country = newSupplier.Country;
            supplier.City = newSupplier.City;
            supplier.SubCity = newSupplier.SubCity;
            supplier.HouseNo = newSupplier.HouseNo;
            supplier.PostalCode = newSupplier.PostalCode;
            supplier.Balance = newSupplier.Balance;
            supplier.Active = newSupplier.Active;
            return supplier;
        }

        public SupplierViewModel SupplierView(Suppliers suppliers)
        {
            var supplier = new SupplierViewModel();

            supplier.id = suppliers.Id;
            supplier.FullName = suppliers.FullName;
            supplier.Email = suppliers.Email;
            supplier.PhoneNo = suppliers.PhoneNo;
            supplier.Country = suppliers.Country;
            supplier.City = suppliers.City;
            supplier.SubCity = suppliers.SubCity;
            supplier.PostalCode = suppliers.PostalCode;
            supplier.Balance = suppliers.Balance;
            supplier.Active = suppliers.Active;

            return supplier;

        }

        public Suppliers UpdateSupplier(Suppliers currentSupplier, UpdateSupplierModel updateSupplier)
        {
            currentSupplier.FullName = updateSupplier.FullName;
            currentSupplier.Email = updateSupplier.Email;
            currentSupplier.PhoneNo = updateSupplier.Phone_No;
            currentSupplier.Country = updateSupplier.Country;
            currentSupplier.City = updateSupplier.City;
            currentSupplier.SubCity = updateSupplier.SubCity;
            currentSupplier.HouseNo = updateSupplier.HouseNo;
            currentSupplier.PostalCode = updateSupplier.PostalCode;
            currentSupplier.Balance = updateSupplier.Balance;
            currentSupplier.Active = updateSupplier.Active;

            return currentSupplier;
        }

        public Suppliers UpdateSuppliers(Suppliers supplier, UpdateSupplierModel updateSupplier)
        {
            throw new System.NotImplementedException();
        }
    }
}