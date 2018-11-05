/*
 * @CreateTime: Nov 2, 2018 3:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:08 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Taxes {
    public partial class Tax {
        public uint Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string TaxType {get; set;}
        public string AccountId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? IncludeInPrice { get; set; }

    }
}