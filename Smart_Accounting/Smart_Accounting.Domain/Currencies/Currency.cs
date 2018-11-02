/*
 * @CreateTime: Nov 2, 2018 3:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:03 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.ExchangeRates;
using Smart_Accounting.Domain.Jornals;

namespace Smart_Accounting.Domain.Currencies {
    public partial class Currency {

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Abrevation { get; set; }
        public string Symbole { get; set; }
        public string Country { get; set; }
    }
}