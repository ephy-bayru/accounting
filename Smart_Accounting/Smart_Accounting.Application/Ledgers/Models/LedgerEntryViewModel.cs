/*
 * @CreateTime: Oct 17, 2018 2:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:30 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class LedgerEntryViewModel {
        public uint Id { get; set; }
        public uint JornalId { get; set; }
        public float Credit { get; set; }
        public float Debit { get; set; }
        public uint Reference {get; set;}
        public string Description {get; set;} 
        public DateTime CreatedOn { get; set; }
        public uint PeriodId { get; set; }
        public string Period { get; set; }
        public DateTime DateAdded {get; set;}
        public DateTime DateUpdated {get; set;}
    }
}