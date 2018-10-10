/*
 * @CreateTime: Oct 10, 2018 9:17 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 10:01 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Application.Supplier.Interfaces {
    public interface ISuppliersQuery {
        Suppliers GetById (uint supplierId);
        SupplierAccount GetSupplierAccountById (uint id);
        IEnumerable<SupplierAccount> GetAllSupplierAccounts ();
        IEnumerable<Suppliers> GetAll ();
    }
}