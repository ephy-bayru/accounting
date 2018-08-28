using System.Collections.Generic;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Interfaces {
    public interface ISuppliersQuery {
        Suppliers GetById(uint supplierId);
        IEnumerable<Suppliers> GetAll();
    }
}