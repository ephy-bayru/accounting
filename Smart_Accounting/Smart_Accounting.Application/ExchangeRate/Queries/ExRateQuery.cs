using Smart_Accounting.Application.ExchnageRate.Commands.Factories;
using Smart_Accounting.Application.ExchnageRate.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.ExchangeRates;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Accounting.Application.ExchnageRate.Queries
{
    public class ExRateQuery : IExRateQueries
    {
        private IAccountingDatabaseService _database;
        public IExRateCommandsFactory _factory;
        public ExRateQuery(
            IAccountingDatabaseService database,
            IExRateCommandsFactory factory)
        {
            _database = database;
            _factory = factory;
        }
        public IEnumerable<ExchangeRate> GetAll() => _database.ExchangeRate.AsNoTracking();
        public ExchangeRate GetById(uint id)
        {
            var exRate = _database.ExchangeRate.Find(id);
            return exRate;
        }

    }
}