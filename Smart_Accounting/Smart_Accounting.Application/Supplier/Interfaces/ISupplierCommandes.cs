using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Interfaces {
    public interface ISupplierCommandes {
        Suppliers Create (NewSupplierModel newSupplier);
        bool Update (Suppliers supplier, UpdateSupplierModel updateSupplier);
        bool Delete (Suppliers suppliers);
    }
}