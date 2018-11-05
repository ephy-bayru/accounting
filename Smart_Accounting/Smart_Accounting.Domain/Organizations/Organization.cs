/*
 * @CreateTime: Sep 4, 2018 12:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:07 PM
 * @Description: Database Organization Database Enitity
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Oranizations {
    public class Organization {
        public Organization()
        {
            AccountChart = new HashSet<AccountChart>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Tin { get; set; }
        public string Organizationcol { get; set; }

        public ICollection<AccountChart> AccountChart { get; set; }
    }

}