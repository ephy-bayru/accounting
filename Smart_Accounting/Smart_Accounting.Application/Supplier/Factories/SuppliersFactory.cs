/*
 * @CreateTime: Oct 9, 2018 12:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 4:17 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Factories {
    public class SupplierFactory : ISuppliersFactory {
        public List<SupplierViewModel> createSupplierView (IEnumerable<Suppliers> supplier) {

            List<SupplierViewModel> supplierViews = new List<SupplierViewModel> ();

            foreach (var item in supplier) {
                SupplierViewModel view = new SupplierViewModel () {
                    id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    Country = item.Country,
                    City = item.City,
                    SubCity = item.SubCity,
                    PostalCode = item.PostalCode
                };
                supplierViews.Add (view);
            }
            return supplierViews;
        }

        public Suppliers CreateNewSupplier (NewSupplierModel supplier) {
            Suppliers newSupplier = new Suppliers () {
                FullName = supplier.FullName,
                City = supplier.City,
                Country = supplier.Country,
                PostalCode = supplier.PostalCode,
                SubCity = supplier.SubCity,
                PhoneNo = supplier.Phone_No,
                Email = supplier.Email
            };

            foreach (var account in supplier.Accounts) {
                newSupplier.SupplierAccount.Add (new SupplierAccount () {
                    BankName = account.BankName,
                        AccountNumber = account.AccountNumber
                });
            }

            return newSupplier;
        }

        public Suppliers UpdatedSupplier (UpdateSupplierModel updatedSupplier) {
            Suppliers supplier = new Suppliers () {
                Id = updatedSupplier.id,
                FullName = updatedSupplier.FullName,
                Email = updatedSupplier.Email,
                PhoneNo = updatedSupplier.Phone_No,
                Country = updatedSupplier.Country,
                City = updatedSupplier.City,
                SubCity = updatedSupplier.SubCity,
                PostalCode = updatedSupplier.PostalCode
            };

            foreach (var account in updatedSupplier.Accounts) {
                supplier.SupplierAccount.Add (new SupplierAccount () {
                    Id = account.Id,
                        BankName = account.BankName,
                        AccountNumber = account.AccountNumber,
                        SupplierId = updatedSupplier.id
                });
            }
            return supplier;
        }
    }
}