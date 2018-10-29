/*
 * @CreateTime: Oct 27, 2018 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 27, 2018 11:22 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class LedgerEntryViewModel {
        public uint Id { get; set; }
        public string Description { get; set; }

        public string Period { get; set; }
        public DateTime CreatedOn { get; set; }
       public List<JornalEntryViewModel> Jornals = new List<JornalEntryViewModel>();
    }
}