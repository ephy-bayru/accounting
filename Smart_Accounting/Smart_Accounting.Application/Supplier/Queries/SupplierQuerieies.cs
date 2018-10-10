using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Supplier.Commands.Factories;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Queries {
    public class SuppliersQuery : ISuppliersQuery {
        private readonly IAccountingDatabaseService _database;
        public ISupplierCommandsFactory _factory;

        public SuppliersQuery (
            IAccountingDatabaseService database,
            ISupplierCommandsFactory factory
        ) {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<Suppliers> GetAll () {
            return _database.Suppliers.ToList ();
        }

        public SupplierAccount GetAllSupplierAccounts () {
            throw new System.NotImplementedException ();
        }

        public Suppliers GetById (uint id) {
            var supplier = _database.Suppliers.Where (sup => sup.Id == id)
            .Select(vendor => new Suppliers() {
                Id = vendor.Id,
                FullName = vendor.FullName,
                Email = vendor.Email,
                PostalCode = vendor.PostalCode,
                SubCity = vendor.SubCity,
                HouseNo = vendor.HouseNo,
                City = vendor.City,
                Country = vendor.Country,
                DateCreated = vendor.DateCreated,
                DateUpdated = vendor.DateUpdated,
                SupplierAccount =  vendor.SupplierAccount.Select(account => new SupplierAccount() {
                    AccountNumber = account.AccountNumber,
                    BankName = account.BankName,
                    Id = account.Id,
                    SupplierId = account.SupplierId
                }).ToList()

            }).FirstOrDefault ();
            return supplier;
        }

        public SupplierAccount GetSupplierAccountById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}