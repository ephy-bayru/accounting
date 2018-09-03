using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.CalendarPeriods;


namespace Smart_Accounting.Application.CalendarPeriods.Queries
{
    public class CalendarPeriodsQuery : ICalendarPeriodQueries{

    private IAccountingDatabaseService _database;

    public CalendarPeriodsQuery (IAccountingDatabaseService database)
    {
        _database = database;
    }

        public IEnumerable<CalendarPeriod> GetAll()
        {
            return _database.CalendarPeriod.ToList();
        }

        public CalendarPeriod GetById(uint Id)
        {
            throw new System.NotImplementedException();
        }
    }
}