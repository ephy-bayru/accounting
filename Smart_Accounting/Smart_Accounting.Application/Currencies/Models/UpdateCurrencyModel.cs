using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Currencies.Models {
    public class UpdateCurrencyModel : CurrencyDto {
        [Required]
        public uint CurrencyId { get; set; }
    }
}