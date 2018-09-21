using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.CalendarPeriods.Models {
    public class CalanderPeriodDto {
        [Required]
        public DateTime Start{get; set;}
        [Required]
        public DateTime End{get; set;}
        [Required]
        public bool active {get; set;}
    }
}