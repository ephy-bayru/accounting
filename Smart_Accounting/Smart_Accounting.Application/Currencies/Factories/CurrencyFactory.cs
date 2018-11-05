using System.Collections.Generic;
using Smart_Accounting.Application.Currencies.Interfaces;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Domain.Currencies;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.Currencies.Factories {
    public class CurrunciesFactory : ICurrencyFactory {
        public List<CurrencyViewModel> createCurrencyView (IEnumerable<Currency> currencies) {
            
            List<CurrencyViewModel> currenciesViews = new List<CurrencyViewModel> ();
            
            foreach (var item in currencies) {
                CurrencyViewModel view = new CurrencyViewModel () {
                    id = item.Id,
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
            };
            return currency;
        }
        public Currency newcrncy (NewCurrencyModel newCurrencyModel) {
            Currency currency = new Currency() {
                Name = newCurrencyModel.name,
                Symbole = newCurrencyModel.symbole,
                Abrevation = newCurrencyModel.symbole,
                Country = newCurrencyModel.country,
            };
            ExchangeRate xrate = new ExchangeRate() {
                BuyRate = newCurrencyModel.ExchangeRate.BuyRate,
                SaleRate = newCurrencyModel.ExchangeRate.SaleRate,
                Date = newCurrencyModel.ExchangeRate.Date,
            };
            
            return currency;
        }
        public Currency UpdateCurrency (UpdateCurrencyModel updateCurrency) {
            Currency currency = new Currency() {
                Name = updateCurrency.name,
                Symbole = updateCurrency.symbole,
                Abrevation = updateCurrency.abrevation,
                Country = updateCurrency.country
            };
            // ExchangeRate uxrate = new ExchangeRate() {
            //     BuyRate = updateCurrency.ExchangeRate.BuyRate,
            //     SaleRate = updateCurrency.ExchangeRate.SaleRate,
            //     Date = updateCurrency.ExchangeRate.Date
            // };
            
            return currency;
        }
    }
}