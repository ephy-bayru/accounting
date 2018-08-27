using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class ExchangeRate
    {
        public ExchangeRate()
        {
            Currency = new HashSet<Currency>();
        }

        public uint RateId { get; set; }
        public string CurrencyCode { get; set; }
        public float BuyRate { get; set; }
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Currency> Currency { get; set; }
    }
}
