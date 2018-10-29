using Smart_Accounting.Application.ExchnageRate.Commands.Factories;
using Smart_Accounting.Application.ExchnageRate.Interfaces;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Application.ExchnageRate.Commands
{
    public class ExRateCommand : IExRateCommands
    {
        private readonly IAccountingDatabaseService _database;
        private IExRateCommandsFactory _exRateCmdFactory;
        public ExRateCommand(
             IAccountingDatabaseService database,
             IExRateCommandsFactory exRateCmdFactory
             )
        {
            _database = database;
            _exRateCmdFactory = exRateCmdFactory;
        }
        public void Create(ExchangeRate exchangeRate)
        {
            var exRate = _exRateCmdFactory.NewExRate(exchangeRate);
            _database.ExchangeRate.Add(exRate);
            _database.Save();

        }
        public void Update(ExchangeRate exchangeRate, UpdateExRateModel updateExRateModel)
        {
            _database.ExchangeRate.Update(exchangeRate);
            _database.Save();
        }
        public void Delete(ExchangeRate exchangeRate)
        {
            _database.ExchangeRate.Remove(exchangeRate);
            _database.Save();
        }

    }
}