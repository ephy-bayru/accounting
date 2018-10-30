using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Domain.ExchangeRates {
    public partial class ExchangeRate {
        public uint Id { get; set; }
        public float BuyRate { get; set; }
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
    }
}