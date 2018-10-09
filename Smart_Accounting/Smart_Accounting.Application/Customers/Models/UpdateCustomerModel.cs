/*
 * @CreateTime: Oct 9, 2018 4:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 4:09 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.Customers.Models.AccountModels;

namespace Smart_Accounting.Application.Customers.Models {
    public class UpdateCustomerModel : CustomerDto {
        [Required]
        public uint id { get; set; }
        public IEnumerable<UpdatedCustomerAccountDto> BankAccounts { get; set; } = new List<UpdatedCustomerAccountDto> ();
    }
}