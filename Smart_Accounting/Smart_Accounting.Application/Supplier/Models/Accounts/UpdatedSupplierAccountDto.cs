/*
 * @CreateTime: Oct 9, 2018 11:53 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 4:10 PM
 * @Description: Modify Here, Please 
 */
namespace Smart_Accounting.Application.Supplier.Models.Accounts
{
    public class UpdatedSupplierAccountDto: SupplierAccountsDto
    {
        public uint Id {get; set;}
        public uint SupplierId {get; set;}
        
    }
}