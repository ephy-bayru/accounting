using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Commands.Factories {
    public interface ICurrenciesCommandsFactory {
        Currency NewCurrency (Currency newCurrency);
        Currency UpdatesCurrency (Currency currentCurrency, UpdateCurrencyModel currency);
        CurrencyViewModel CurrenciesView (Currency currency);
    }
}