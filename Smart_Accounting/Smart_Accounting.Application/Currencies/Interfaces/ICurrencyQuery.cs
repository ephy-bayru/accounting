using System.Collections.Generic;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Interfaces {
    public interface ICurrencyQueries {
        Currency GetById (uint id);
        IEnumerable<Currency> GetAll ();
    }
}