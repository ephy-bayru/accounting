using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Supplier.Commands.Factories;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Commands {
    public class SupplierCommand : ISupplierCommandes {
        private readonly IAccountingDatabaseService _database;
        private ISupplierCommandsFactory supplierCommandFactory;
        public SupplierCommand (
            IAccountingDatabaseService database,
            ISupplierCommandsFactory SupplierCommandFactory
        ) {
            _database = database;
            SupplierCommandFactory = supplierCommandFactory;
        }
        public Suppliers Create(Suppliers newSupplier) {
            _database.Suppliers.Add (newSupplier);
            _database.Save ();

            return newSupplier;
        }
        public bool Update (Suppliers supplier, UpdateSupplierModel updateSupplier) {
            _database.Suppliers.Update (supplier).State = EntityState.Modified;
            _database.Save();
            return true;
        }
        public bool Delete (Suppliers suppliers) {
            _database.Suppliers.Remove(suppliers);
            _database.Save();
            return true;
        }
    }
}