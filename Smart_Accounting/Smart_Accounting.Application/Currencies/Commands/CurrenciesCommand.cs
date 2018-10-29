using Smart_Accounting.Application.Currencies.Commands.Factories;
using Smart_Accounting.Application.Currencies.Interfaces;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Application.Currencies.Commands
{
    public class CurrencyCommand : ICurrencyCommands
    {
        private readonly IAccountingDatabaseService _database;
        private ICurrenciesCommandsFactory _currencyCmdFactory;
        public CurrencyCommand(
             IAccountingDatabaseService database,
             ICurrenciesCommandsFactory currencyCmdFactory
             ){
            _database = database;
            _currencyCmdFactory = currencyCmdFactory;
        }
        public void Create(Currency currency)
        {
            var crncy = _currencyCmdFactory.NewCurrency(currency);
            _database.Currency.Add(crncy);
            _database.Save();

        }
        public void Update(Currency currency, UpdateCurrencyModel updateCurrency)
        {
            _database.Currency.Update(currency);
            _database.Save();
        }
         public void Delete(Currency currency)
        {
            _database.Currency.Remove(currency);
            _database.Save();
        }

    }
}