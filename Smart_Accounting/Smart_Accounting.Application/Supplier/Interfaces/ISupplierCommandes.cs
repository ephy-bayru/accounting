using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Interfaces {
    public interface ISupplierCommandes {
        void Create (Suppliers newSupplier);
        void Update (Suppliers suppliers, UpdateSupplierModel updateSupplier);
        void Delete (Suppliers suppliers);
    }
}