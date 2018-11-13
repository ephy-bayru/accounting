using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.Jornals;

namespace Smart_Accounting.Domain.PostingTypes {

    public partial class PostingType
    {
        public PostingType()
        {
            Jornal = new HashSet<Jornal>();
        }

        public uint Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public sbyte System { get; set; }
        public sbyte? Active { get; set; }

        public ICollection<Jornal> Jornal { get; set; }
    }
}
