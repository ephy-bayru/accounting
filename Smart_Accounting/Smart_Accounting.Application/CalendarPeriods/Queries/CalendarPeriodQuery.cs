using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Queries {
    public class CalendarPeriodsQuery : ICalendarPeriodQueries {

        private IAccountingDatabaseService _database;

        public CalendarPeriodsQuery (IAccountingDatabaseService database) {
            _database = database;
        }

        public CalendarPeriod getActivePeriod () {
            return _database.CalendarPeriod
                .Where (period => period.Active == 1)
                .Select (calendar => new CalendarPeriod () {
                    Id = calendar.Id,
                        Start = calendar.Start,
                        End = calendar.End,
                        Active =  calendar.Active,
                        Closed = calendar.Closed

                }).FirstOrDefault ();


        }

        public uint getActivePeriodId () {
            var activeId = _database.CalendarPeriod
                .Where (period => period.Active == 1)
                .Select (calendar => new CalendarPeriod () {
                    Id = calendar.Id

                }).FirstOrDefault ();

            return activeId.Id;
        }
        public IEnumerable<CalendarPeriod> GetAll () {
            return _database.CalendarPeriod.Select (calendar => new CalendarPeriod () {
                Id = calendar.Id,
                    Start = calendar.Start,
                    End = calendar.End,
           
                    Closed = calendar.Closed

            }).ToList ();
        }

        public CalendarPeriod GetById (uint id) {
            return _database.CalendarPeriod
                .Where (period => period.Id == id)
                .Select (calendar => new CalendarPeriod () {
                    Id = calendar.Id,
                        Start = calendar.Start,
                        End = calendar.End,
                        Active = calendar.Active,
                        Closed = calendar.Closed

                }).FirstOrDefault ();

        }

        public IEnumerable<CalanderPeriodListView> GetOpenPeriods () {
            return _database.CalendarPeriod
                .Where (period => period.Closed == 0)
                .Select (calendar => new CalanderPeriodListView () {
                    Id = calendar.Id,
                    Period = $"{calendar.Start} - {calendar.End}",
                        Status = (calendar.Active == 1) ? "Active" : "Not Active",
                        IsClosed = (calendar.Closed == 1) ? true : false

                }).ToList ();
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