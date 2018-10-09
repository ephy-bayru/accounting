using Smart_Accounting.Application.Supplier.Commands.Factories;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Supplier;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Accounting.Application.Supplier.Queries
{
    public class SuppliersQuery : ISuppliersQuery
    {
        private readonly IAccountingDatabaseService _database;
        public ISupplierCommandsFactory _factory;

        public SuppliersQuery(
            IAccountingDatabaseService database,
            ISupplierCommandsFactory factory
         )
        {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<Suppliers> GetAll()
        {
            return _database.Suppliers.ToList();
        }

        public Suppliers GetById(uint id)
        {
            var supplier = _database.Suppliers.AsNoTracking().Where(sup => sup.Id == id).FirstOrDefault();
            return supplier;
        }
    }
}