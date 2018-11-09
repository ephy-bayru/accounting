/*
 * @CreateTime: Sep 24, 2018 9:24 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 24, 2018 9:24 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.CalendarPeriods.Models {
    public class CalanderPeriodDto {
        [Required]
        public DateTime Start{get; set;}
        [Required]
        public DateTime End{get; set;}
        [Required]
        public sbyte active {get; set;}
        [Required]
        public  sbyte isBegining {get; set;}
    }
}