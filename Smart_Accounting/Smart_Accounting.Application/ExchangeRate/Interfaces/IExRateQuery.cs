using System.Collections.Generic;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Interfaces {
    public interface IExRateQueries {
        ExchangeRate GetById (uint id);
        IEnumerable<ExchangeRate> GetAll ();
    }
}