using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.ExchnageRate.Models {
    // Exchange Rate model
    // ─── EXCHANGE RATE VIEW MODEL ────────────────────────────────────────────────────────
    // this model is displayed when a user requests to HTTP GET exchange rate
     public class ExRateViewModel{
        public uint ID { get; set; }
        public float BuyRate {get; set; }
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
     }
}