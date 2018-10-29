using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.ExchnageRate.Models {
    public abstract class ExRateDto {
        [Required]
        public float BuyRate { get; set; }
        [Required]
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
    }
}