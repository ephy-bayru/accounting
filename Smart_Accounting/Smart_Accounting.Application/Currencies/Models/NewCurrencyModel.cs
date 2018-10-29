using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Smart_Accounting.Application.ExchnageRate.Models;

namespace Smart_Accounting.Application.Currencies.Models {
    public class NewCurrencyModel : CurrencyDto {
        public NewExRateModel ExchangeRate {get; set;} = new NewExRateModel();

    }
}