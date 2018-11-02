/*
 * @CreateTime: Nov 2, 2018 3:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:01 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Domain.ExchangeRates {
    public partial class ExchangeRate {
        public uint Id { get; set; }
        public float BuyRate { get; set; }
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Currency { get; set; }
    }
}