using System;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Commands.Factories {
    public class CurrencyCommandsFactory : ICurrenciesCommandsFactory {
        public Currency NewCurrency (Currency newCurrency)
        {
            var currency = new Currency ();
                currency.ID = newCurrency.ID;
                currency.Name = newCurrency.Name;
                currency.Abrevation = newCurrency.Abrevation;
                currency.Symbole = newCurrency.Symbole;
                currency.Country = newCurrency.Country;
            return currency;
        }
        public Currency UpdatesCurrency (Currency currentCurrency, UpdateCurrencyModel currency)
        {
            currentCurrency.ID = currency.ID;
            currentCurrency.Name =currency.name;
            currentCurrency.Abrevation = currency.abrevation;
            currentCurrency.Symbole = currency.symbole;
            currentCurrency.Country = currency.country;

            return currentCurrency;
        }
        public CurrencyViewModel CurrenciesView (Currency currency)
        {
            var currencies = new CurrencyViewModel ();
                currency.ID = currencies.id;
                currency.Name = currencies.name;
                currency.Abrevation = currencies.abrevation;
                currency.Symbole = currencies.symbols;
                currency.Country = currencies.country;

            return currencies;
        }
    }
}