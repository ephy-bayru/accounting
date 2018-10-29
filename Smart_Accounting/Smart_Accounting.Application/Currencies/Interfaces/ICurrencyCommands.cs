using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Interfaces {
    public interface ICurrencyCommands {
        void Create (Currency currency);
        void Update (Currency currency, UpdateCurrencyModel updateCurrency);
        void Delete (Currency currency);
    }
}