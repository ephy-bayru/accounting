/*
 * @CreateTime: Nov 10, 2018 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 11:43 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Commands {
    public class CalendarPeriodsCommands : ICalendarPeriodsCommands {
        private readonly IAccountingDatabaseService _database;
        private readonly ICalendarPeriodsCommandsFactory _calendarCommandFactory;
        private readonly ILogger<CalendarPeriodsCommands> _logger;

        public CalendarPeriodsCommands (IAccountingDatabaseService database,
            ICalendarPeriodsCommandsFactory calendarCommandFactory,
            ILogger<CalendarPeriodsCommands> logger) {
            _database = database;
            _calendarCommandFactory = calendarCommandFactory;
            _logger = logger;
        }

        public IEnumerable<CalendarViewModel> CreateCalendar (IEnumerable<CalendarPeriod> newCalendar) {
            try {
                _database.CalendarPeriod.AddRange (newCalendar);                        
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
            } catch (DbUpdateException e) {
                throw e;
           
            } catch (Exception e) {
            _logger.LogError(500, e, e.Message);
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