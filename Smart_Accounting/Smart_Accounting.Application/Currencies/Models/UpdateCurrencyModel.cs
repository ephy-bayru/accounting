using System;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.ExchnageRate.Models;
using System.Collections.Generic;

namespace Smart_Accounting.Application.Currencies.Models {
    public class UpdateCurrencyModel : CurrencyDto {
        [Required]
        public uint ID { get; set; }
        // public UpdateExRateModel ExchangeRate {get; set;} = new UpdateExRateModel();
    }
}