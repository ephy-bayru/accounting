using System.Collections.Generic;
using Smart_Accounting.Application.SystemDefault.Interfaces;
using Smart_Accounting.Domain.SystemDefault;

namespace Smart_Accounting.Application.SystemDefault.Queries {
    public class SystemDefaultQuery : ISystemDefaultQuery {
        public IEnumerable<SystemDefaults> GetAll () {
            throw new System.NotImplementedException ();
        }

        public IEnumerable<SystemDefaults> GetByCatagory (string catagory) {
            throw new System.NotImplementedException ();
        }

        public SystemDefaults GetById () {
            throw new System.NotImplementedException ();
        }
    }
}