/*
 * @CreateTime: Oct 9, 2018 11:52 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 11:52 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Supplier.Models.Accounts {
    public abstract class SupplierAccountsDto {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string BankName { get; set; }
    }
}