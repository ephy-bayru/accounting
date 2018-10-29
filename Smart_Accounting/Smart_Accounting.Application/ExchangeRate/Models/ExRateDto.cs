using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.ExchnageRate.Models {
    public abstract class ExRateDto {
        [Required]
        public string CurrencyCode {get; set; }
        [Required]
        public float BuyRate { get; set; }
        [Required]
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
    }
}