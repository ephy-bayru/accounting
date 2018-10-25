using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Domain.ExchangeRates {
    public partial class ExchangeRate {
        public ExchangeRate () {
            Currency = new HashSet<Currency> ();
        }
        public uint Id { get; set; }
        public string CurrencyCode { get; set; }
        public float BuyRate { get; set; }
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Currency> Currency { get; set; }
    }
}