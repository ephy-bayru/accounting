using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain
{
    public partial class AccountType
    {
        public AccountType()
        {
            AccountChart = new HashSet<AccountChart>();
        }

        public uint AccTypeId { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }

        public ICollection<AccountChart> AccountChart { get; set; }
    }
}
