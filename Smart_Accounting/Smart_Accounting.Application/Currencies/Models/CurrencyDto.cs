using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Currencies.Models {
    public abstract class CurrencyDto {
        [Required]
        public string name {get; set; }
        [Required]
        public string abrevation { get; set; }
        [Required]
        public string symbole { get; set; }
        public string country { get; set; }
        public string exchange_rate { get; set; }
    }
}