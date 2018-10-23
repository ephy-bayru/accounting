using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Currencies.Models {
    // currency model
    // ─── CURRENCY VIEW MODEL ────────────────────────────────────────────────────────
    // this model is displayed when a user requests to HTTP GET currency
     public class CurrencyViewModel{
        public uint id { get; set; }
        public string name {get; set; }
        public string abrevation { get; set; }
        public string symbols { get; set; }
        public string country { get; set; }

     }
}