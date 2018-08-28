using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Oranizations {
    public partial class Organization {
        public Organization () {
            AccountChart = new HashSet<AccountChart> ();
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