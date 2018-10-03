using System.Collections.Generic;
using Smart_Accounting.Domain.Supplier;
using Smart_Accounting.Application.Supplier.Models;

namespace Smart_Accounting.Application.Supplier.Interfaces
{
    public interface ISuppliersFactory
    {
        List<SupplierViewModel> createSupplierView(IEnumerable<Suppliers> supplier);
    }
}