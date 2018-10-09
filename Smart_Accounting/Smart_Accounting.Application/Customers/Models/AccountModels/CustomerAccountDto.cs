/*
 * @CreateTime: Oct 9, 2018 10:13 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 10:16 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Customers.Models.AccountModels {
    public abstract class CustomerAccountDto {
        [Required]
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}