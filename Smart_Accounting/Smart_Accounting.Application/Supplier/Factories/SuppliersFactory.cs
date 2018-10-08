using System.Collections.Generic;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Factories
{
    public class SupplierFactory : ISuppliersFactory
    {
        public List<SupplierViewModel> createSupplierView(IEnumerable<Suppliers> supplier)
        {

            List<SupplierViewModel> supplierViews = new List<SupplierViewModel>();

            foreach (var item in supplier)
            {
                SupplierViewModel view = new SupplierViewModel()
                {
                    id = item.Id,
                    FullName = item.FullName,
                    AccountId = item.AccountId,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    Country = item.Country,
                    City = item.City,
                    SubCity = item.SubCity,
                    PostalCode = item.PostalCode
                };
                supplierViews.Add(view);
            }
            return supplierViews;
        }

        public Suppliers CreateNewSupplier(NewSupplierModel supplier)
        {
            return new Suppliers() {

                FullName = supplier.FullName,
                PhoneNo = supplier.Phone_No,
                Email = supplier.Email
            };
        }
    }
}