using System.Collections.Generic;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Interfaces
{
    public interface ICurrencyFactory
    {
        List<CurrencyViewModel> createCurrencyView(IEnumerable<Currency> currencies);
    }
}