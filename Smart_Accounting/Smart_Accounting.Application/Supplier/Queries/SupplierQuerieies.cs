using System.Collections.Generic;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Queries {
    public class SuppliersQuery : ISuppliersQuery {
        public IEnumerable<Suppliers> GetAll () {
            throw new System.NotImplementedException ();
        }

        public Suppliers GetById (uint supplierId) {
            throw new System.NotImplementedException ();
        }
    }
}