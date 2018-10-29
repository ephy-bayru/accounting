using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Interfaces {
    public interface IExRateCommands {
        void Create (ExchangeRate exRate);
        void Update (ExchangeRate currency, UpdateExRateModel updateExRate);
        void Delete (ExchangeRate exRate);
    }
}