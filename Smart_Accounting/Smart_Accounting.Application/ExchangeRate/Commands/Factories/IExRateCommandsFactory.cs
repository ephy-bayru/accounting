using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Commands.Factories {
    public interface IExRateCommandsFactory {
        ExchangeRate NewExRate (ExchangeRate newExRate);
        ExchangeRate UpdatesExRate (ExchangeRate currentExRate, UpdateExRateModel exRate);
        ExRateViewModel ExRateView (ExchangeRate exRate);
    }
}