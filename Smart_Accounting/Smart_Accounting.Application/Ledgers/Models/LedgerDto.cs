/*
 * @CreateTime: Oct 17, 2018 2:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:05 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Ledgers.Models {
    public  class LedgerDto {
        [Required]
        public DateTime CreatedOn {get; set;}
        [Required]
        public uint PeriodId {get; set;}
        public string Description {get; set;}
    }
}