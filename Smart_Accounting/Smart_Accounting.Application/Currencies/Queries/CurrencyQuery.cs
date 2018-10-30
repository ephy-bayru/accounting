using Smart_Accounting.Application.Currencies.Commands.Factories;
using Smart_Accounting.Application.Currencies.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.Currencies;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Accounting.Application.Currencies.Queries
{
    public class CurrenciesQuery : ICurrencyQueries
    {
        private IAccountingDatabaseService _database;
        public ICurrenciesCommandsFactory _factory;
        public CurrenciesQuery(
            IAccountingDatabaseService database,
            ICurrenciesCommandsFactory factory)
        {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<Currency> GetAll() => _database.Currency.AsNoTracking();
        public Currency GetById(uint id)
        {
            var currency = _database.Currency.Find(id);
            return currency;
        }

    }
}