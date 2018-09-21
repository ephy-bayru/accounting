using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Queries {
    public class CalendarPeriodsQuery : ICalendarPeriodQueries {

        private IAccountingDatabaseService _database;

        public CalendarPeriodsQuery (IAccountingDatabaseService database) {
            _database = database;
        }

        public IEnumerable<CalendarPeriod> GetAll () {
            return _database.CalendarPeriod.ToList ();
        }

        public CalendarPeriod GetById (uint id) {
            var calendar = _database.CalendarPeriod.Find (id);
            return calendar;

        }
        public bool IsEndDateOveraped (DateTime endDate) {
            var overlaped = _database.CalendarPeriod.Where (cal => cal.End.Date >= endDate.Date)
                .Where (cal => cal.Start.Date <= endDate.Date).ToList ();
            return (overlaped.Count == 0) ? false : true;
        }

        public bool IsStartDateOveraped (DateTime startDate) {
            var overlaped = _database.CalendarPeriod.Where (cal => cal.Start.Date <= startDate.Date)
                .Where (cal => cal.End.Date >= startDate.Date).ToList ();
            return (overlaped.Count == 0) ? false : true;
        }
    }
}