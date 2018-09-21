using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Commands {
    public class CalendarPeriodsCommands : ICalendarPeriodsCommands {
        private readonly IAccountingDatabaseService _database;
        private readonly ICalendarPeriodsCommandsFactory _calendarCommandFactory;

        public CalendarPeriodsCommands (IAccountingDatabaseService database,
            ICalendarPeriodsCommandsFactory calendarCommandFactory) {
            _database = database;
            _calendarCommandFactory = calendarCommandFactory;
        }

        public IEnumerable<CalendarViewModel> CreateCalendar (IEnumerable<CalendarPeriod> newCalendar) {
            try {

                foreach (var item in newCalendar) {
                _database.CalendarPeriod.Add (item);
                }
                
                _database.Save ();

                return _calendarCommandFactory.CalendarView (newCalendar);
            } catch (Exception) {
                return null;
            }
        }

        public bool DeleteCalendar (CalendarPeriod calender) {
            try {
                _database.CalendarPeriod.Remove (calender);
                _database.Save (); // save change in the database
                return true;
            } catch (Exception) {
                return false;
            }

        }

        public bool UpdateCalendar (CalendarPeriod updatedCalander) {

                _database.CalendarPeriod.Update (updatedCalander);
                _database.Save ();
                return true;
        }
    }
}