using System.Collections.Generic;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.Supplier.Queries
{
    public class SupplierQuerieies : ISuppliersQuery
    {
        public IEnumerable<Suppliers> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Suppliers GetById(uint supplierId)
        {
            throw new System.NotImplementedException();
        }
    }
}