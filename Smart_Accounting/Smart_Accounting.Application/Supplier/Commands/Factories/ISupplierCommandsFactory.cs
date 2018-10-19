using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Commands.Factories {
    public interface ISupplierCommandsFactory {
        Suppliers NewSupplier (Suppliers newSupplier);
        Suppliers UpdateSuppliers(Suppliers supplier, UpdateSupplierModel updateSupplier);
        SupplierViewModel SupplierView(Suppliers supplier);
    }
}
