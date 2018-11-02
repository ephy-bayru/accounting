/*
 * @CreateTime: Nov 2, 2018 3:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:00 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Jornals;

namespace Smart_Accounting.Domain.Ledgers {
    public class Ledger {
        public uint Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint PeriodId { get; set; }
        public string Discription { get; set; }
        public string PostType { get; set; }
        public string DocumentNo { get; set; }

        public CalendarPeriod Period { get; set; }
    }
}