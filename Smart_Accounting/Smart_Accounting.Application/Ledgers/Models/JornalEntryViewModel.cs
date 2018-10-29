/*
 * @CreateTime: Oct 17, 2018 2:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 27, 2018 11:18 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class JornalEntryViewModel {
        
        public uint Id { get; set; }
        public string Account { get; set; }
        public string AccountId { get; set; }
        public float Credit { get; set; }
        public float Debit { get; set; }
        public uint Reference {get; set;}
        public DateTime DateAdded {get; set;}
        public DateTime DateUpdated {get; set;}
    }
}