/*
 * @CreateTime: Nov 3, 2018 11:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 11:43 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.AccountCharts.Models {
    public class NewAccountModel : AccountChartDto {
        [Required]
        public float OpeningBalance {get; set;} // holds the balance of the account
    }
}