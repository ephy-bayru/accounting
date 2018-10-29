using System.Collections.Generic;
using Smart_Accounting.Application.ExchnageRate.Interfaces;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Factories
{
    public class ExRateFactory : IExRateFactory
    {
        public ExchangeRate CreateNewExRate(NewExRateModel newExRate)
        {
            ExchangeRate exrate = new ExchangeRate();
            {
                exrate.SaleRate = newExRate.SaleRate;
                exrate.SaleRate = newExRate.BuyRate;
                exrate.Date = newExRate.Date;
            }
            return exrate;
        }
        ExchangeRate IExRateFactory.UpdateExRate(ExchangeRate exRate, UpdateExRateModel updateExRate)
        {
            exRate.BuyRate = updateExRate.BuyRate;
            exRate.SaleRate = updateExRate.SaleRate;
            exRate.Date = exRate.Date;
            return exRate;
        }
        List<ExRateViewModel> IExRateFactory.createExRateView(IEnumerable<ExchangeRate> exRate)
        {
            List<ExRateViewModel> exRateViews = new List<ExRateViewModel>();
            foreach (var item in exRateViews)
            {
                ExRateViewModel view = new ExRateViewModel()
                {
                    ID = item.ID,
                    BuyRate = item.BuyRate,
                    SaleRate = item.SaleRate,
                    Date = item.Date,
                };
                exRateViews.Add(view);
            }
            return exRateViews;

        }

    }
}
