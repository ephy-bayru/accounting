using System.Collections.Generic;
using Smart_Accounting.Domain.SystemDefault;

namespace Smart_Accounting.Application.SystemDefault.Interfaces {
    public interface ISystemDefaultQuery {
        SystemDefaults GetById ();

        IEnumerable<SystemDefaults> GetAll ();

        IEnumerable<SystemDefaults> GetByCatagory (string catagory);
    }
}