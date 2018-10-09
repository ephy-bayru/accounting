using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Interfaces {
    public interface ISupplierCommandes {
        Suppliers Create (Suppliers newSupplier);
        bool Update (Suppliers suppliers, UpdateSupplierModel updateSupplier);
        bool Delete (Suppliers suppliers);
    }
}