/*
 * @CreateTime: Oct 9, 2018 10:18 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 3:43 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Customers.Models.AccountModels {
    public class UpdatedCustomerAccountDto : CustomerAccountDto {
        [Required]
        public uint Id { get; set; }
        [Required]
        public uint CustomerId { get; set; }

    }
}