using System.Collections.Generic;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Interfaces
{
    public interface IExRateFactory
    {
        List<ExRateViewModel> createExRateView(IEnumerable<ExchangeRate> exRate);
        List<ExchangeRate> CreateNewExRate(NewExRateModel newExRate);
        ExchangeRate UpdateExRate(ExchangeRate exRate, UpdateExRateModel updateExRate);
    }
}