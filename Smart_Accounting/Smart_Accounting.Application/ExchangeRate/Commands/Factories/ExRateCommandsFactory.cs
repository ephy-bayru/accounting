using System;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Commands.Factories {
    public class ExRateCommandsFactory : IExRateCommandsFactory {
        public ExchangeRate NewExRate (ExchangeRate newExRate)
        {
            var exRate = new ExchangeRate ();
                exRate.Id = newExRate.Id;
                exRate.BuyRate = newExRate.BuyRate;
                exRate.SaleRate = newExRate.SaleRate;
                exRate.Date = newExRate.Date;

            return exRate;
        }
        public ExchangeRate UpdatesExRate (ExchangeRate currentExRate, UpdateExRateModel updateExRate)
        {
            currentExRate.BuyRate = updateExRate.BuyRate;
            currentExRate.SaleRate = updateExRate.SaleRate;
            currentExRate.Date = updateExRate.Date;

            return currentExRate;
        }
        public ExRateViewModel ExRateView (ExchangeRate exRate)
        {
            var exRateV = new ExRateViewModel ();
                exRate.BuyRate = exRateV.BuyRate;
                exRate.SaleRate = exRateV.SaleRate;
                exRate.Date = exRateV.Date;

            return exRateV;
        }
    }
}