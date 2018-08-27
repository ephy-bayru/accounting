﻿using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class Currency
    {
        public Currency()
        {
            Jornal = new HashSet<Jornal>();
        }

        public uint CurrencyId { get; set; }
        public string Name { get; set; }
        public string Abrevation { get; set; }
        public string Symbole { get; set; }
        public string Country { get; set; }
        public uint ExchangeRateRateId { get; set; }

        public ExchangeRate ExchangeRateRate { get; set; }
        public ICollection<Jornal> Jornal { get; set; }
    }
}
