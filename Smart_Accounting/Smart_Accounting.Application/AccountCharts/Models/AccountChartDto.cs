/*
 * @CreateTime: Sep 25, 2018 12:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 4:12 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.AccountCharts.Models {
    public abstract class AccountChartDto {

        public string AccountCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AccountId { get; set; }
        public sbyte Active { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public uint OrganizationId { get; set; }
    }
}