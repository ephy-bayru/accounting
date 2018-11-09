/*
 * @CreateTime: Nov 9, 2018 4:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 9, 2018 4:44 PM
 * @Description: Class that implements the ICalendarPeriodQuariable 
 *      to perform the all the read operations related to calendar period
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Queries {
    public class CalendarPeriodsQuery : ICalendarPeriodQueries {

        private readonly IAccountingDatabaseService _database;
        private readonly ILogger<CalendarPeriodsQuery> _logger;

        public CalendarPeriodsQuery (IAccountingDatabaseService database,
            ILogger<CalendarPeriodsQuery> logger) {
            _database = database;
            _logger = logger;
        }

        /// <summary>
        /// Defines a private general method that will be used 
        /// to perform operation on calendar period
        /// </summary>
        /// <returns>IQueryable<CalendarPeriod></returns>
        private IQueryable<CalendarPeriod> CalendarPeriodIQuariable () {
            try {
                return _database.CalendarPeriod
                    .Select (calendar => new CalendarPeriod () {
                        Id = calendar.Id,
                            Start = calendar.Start,
                            End = calendar.End,
                            Active = calendar.Active,
                            Closed = calendar.Closed,
                            DateAdded = calendar.DateAdded,
                            DateUpdated = calendar.DateUpdated

                    });
            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return null;
            }

        }

        /// <summary>
        /// Retuens the active period
        /// </summary>
        /// <returns></returns>
        public CalendarPeriod getActivePeriod () {
            try {
                return CalendarPeriodIQuariable ()
                    .FirstOrDefault (period => period.Active == 1);
            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return null;
            }

        }
        /// <summary>
        /// Returns the Id of the Active Period
        /// </summary>
        /// <returns></returns>
        public uint getActivePeriodId () {
            try {
                var activeId = _database.CalendarPeriod
                    .Where (period => period.Active == 1)
                    .Select (calendar => new CalendarPeriod () {
                        Id = calendar.Id

                    }).FirstOrDefault ();

                return activeId.Id;

            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Used to retrive all records of calendar periof
        /// </summary>
        /// <returns>IEnumerable<CalendarPeriod></returns>
        public IEnumerable<CalendarPeriod> GetAll () {
            try {

                return CalendarPeriodIQuariable ()
                    .ToList ();

            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return null;
            }
        }

        /// <summary>
        /// used to get a certain period recored based on it's Id
        /// </summary>
        /// <param name="periodId"></param>
        /// <returns>CalendarPeriod</returns>
        public CalendarPeriod GetById (uint periodId) {
            try {

                return CalendarPeriodIQuariable ()
                    .FirstOrDefault (period => period.Id == periodId);

            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return null;
            }

        }

        /// <summary>
        /// Returns array of all periods that are currently open
        /// </summary>
        /// <returns>IEnumerable<CalanderPeriodListView></returns>
        public IEnumerable<CalanderPeriodListView> GetOpenPeriods () {
            try {

                return CalendarPeriodIQuariable ()
                    .Where (period => period.Closed == 0)
                    .Select (calendar => new CalanderPeriodListView () {
                        Id = calendar.Id,
                            Period = $"{calendar.Start} - {calendar.End}",
                            Status = (calendar.Active == 1) ? "Active" : "Not Active",
                            IsClosed = (calendar.Closed == 1) ? true : false

                    }).ToList ();

            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return null;
            }
        }

        /// <summary>
        /// Checks to see if End date value passed in parameter overlaps with existing date values
        /// </summary>
        /// <param name="endDate"></param>
        /// <returns>bool</returns>
        public bool IsEndDateOveraped (DateTime endDate) {
            try {

                var overlaped = _database.CalendarPeriod.Where (cal => cal.End.Date >= endDate.Date)
                    .Where (cal => cal.Start.Date <= endDate.Date).ToList ();
                return (overlaped.Count == 0) ? false : true;

            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks to see if start date value passed in parameter overlaps with existing date values
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns>bool</returns>
        public bool IsStartDateOveraped (DateTime startDate) {
            try {

                var overlaped = _database.CalendarPeriod.Where (cal => cal.Start.Date <= startDate.Date)
                    .Where (cal => cal.End.Date >= startDate.Date).ToList ();
                return (overlaped.Count == 0) ? false : true;

            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return false;
            }
        }
    }
}