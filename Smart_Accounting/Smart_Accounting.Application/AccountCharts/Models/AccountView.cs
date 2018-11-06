/*
 * @CreateTime: Nov 6, 2018 3:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 5:22 PM
 * @Description:  
 */

using System;

namespace Smart_Accounting.Application.AccountCharts.Models {
    public class AccountView {
        public string AccountId { get; set; }
        public string ParentAccount { get; set; }
        public string AccountName { get; set; }
        public double TotalAmount {get; set;}
        public DateTime? DateAdded {get; set;}
        public DateTime? DateUpdated {get; set;}

    }
}