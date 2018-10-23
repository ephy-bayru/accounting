using System.Collections.Generic;
using Smart_Accounting.Application.Currencies.Interfaces;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Factories {
    public class CurrunciesFactory : ICurrencyFactory {
        public List<CurrencyViewModel> createCurrencyView (IEnumerable<Currency> currencies) {
            
            List<CurrencyViewModel> currenciesViews = new List<CurrencyViewModel> ();
            
            foreach (var item in currencies) {
                CurrencyViewModel view = new CurrencyViewModel () {
                    id = item.CurrencyId,
                    name = item.Name,
                    abrevation = item.Abrevation,
                    symbols = item.Symbole,
                    country = item.Country
                };
                currenciesViews.Add (view);
            }
            return currenciesViews;
        }
         public IEnumerable<Currency> NewCurrency (IEnumerable<NewCurrencyModel> newCurrencies) {
            List<Currency> currency = new List<Currency> ();

            foreach (var item in currency) {
                Currency crncy = new Currency ();
                crncy.Name = item.Name;
                crncy.Symbole = item.Symbole;
                crncy.Abrevation = item.Abrevation;
                crncy.Country = crncy.Country;
                currency.Add(crncy);
            }
            return currency;
        }
        public Currency UpdateCurrency (Currency currency, UpdateCurrencyModel updateCurrency) {
            
            currency.Name = updateCurrency.name;
            currency.Symbole = updateCurrency.symbole;
            currency.Abrevation = updateCurrency.abrevation;
            currency.Country = updateCurrency.country;

            return currency;
        }
    }
}