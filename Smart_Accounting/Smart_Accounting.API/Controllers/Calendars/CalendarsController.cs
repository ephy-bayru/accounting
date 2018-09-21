/*
 * @CreateTime: Sep 14, 2018 3:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 14, 2018 3:36 PM
 * @Description: Calander Period API Controller Class
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.API.Controllers.Calendarss {

    [Route ("api/calanders")]
    public class CalendarsController : Controller {

        private readonly ICalendarPeriodsCommands _calendarCommand;
        private readonly ICalendarPeriodsCommandsFactory _factory;
        private readonly ICalendarPeriodQueries _calendarQuery;
        private readonly IResponseFactory _responseFactory;
        public CalendarsController (ICalendarPeriodQueries calendarQuery,
            ICalendarPeriodsCommands calendarCommand,
            ICalendarPeriodsCommandsFactory factory,
            IResponseFactory response) {
            _calendarQuery = calendarQuery;
            _calendarCommand = calendarCommand;
            _factory = factory;
            _responseFactory = response;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        public IActionResult GetAllCalendarPeriod () {
            var calendars = _calendarQuery.GetAll ();
            var response = _responseFactory.Create ((List<CalendarPeriod>) calendars);
            return Ok (response);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        public IActionResult GetCalendarPeriodById (uint id) {
            var calendar = _calendarQuery.GetById (id);

            return Ok (calendar);
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (IEnumerable<CalendarViewModel>))]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        public IActionResult CreateNewCalendarPeriod ([FromBody] IEnumerable<NewCalendarPeriodDto> newCalendar) {
            try {
                if (ModelState.IsValid || newCalendar != null) {
                    // Checks if the date specified has already been used or not
                    foreach (var item in newCalendar) {
                        if (_calendarQuery.IsEndDateOveraped (item.End) || _calendarQuery.IsStartDateOveraped (item.Start)) {
                            return StatusCode (422, "Overlaping Dates Used");
                        }
                    }

                    // convert the data passed from client to CalanderPeriod object
                    var calanderFactory = _factory.NewCalendar (newCalendar);

                    // add new record in the database
                    var calendar = _calendarCommand.CreateCalendar (calanderFactory);

                    if (calendar != null) {
                        return StatusCode (201, calendar);
                    } else {
                        return StatusCode (500, "unkown error");
                    }
                } else {
                    return StatusCode (422, "required field are missing");
                }
            } catch (Exception) {
                return StatusCode (500, "Something Wrong happened try again later!!!");
            }

        }

        [HttpPut]
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        public IActionResult UpdateCalendarPeriod (uint id, [FromBody] UpdatedCalanderDto data) {

            if (ModelState.IsValid) {

                id = (id == 0) ? data.id : id;

                var calendar = _calendarQuery.GetById (id);
                //  check if calander with the specified id exists
                if (calendar != null) {

                    var calanerFactory = _factory.UpdateCalander (calendar, data);

                    var result = _calendarCommand.UpdateCalendar (calanerFactory);

                    // convert calander data passed from the user to calanderperiod Object

                    if (result != false) {
                        return StatusCode (204); // when updated Successfully

                    } else {

                        return StatusCode (500, "unkown error");
                    }

                } else {

                    return StatusCode (404);
                }
            } else {
                return StatusCode (422, "required field is missing");
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteCalendarPeriod (uint id) {

            try {
                var calendar = _calendarQuery.GetById (id);
                // Get the Calander Specified by the Id

                if (calendar != null) {
                    // if calander exists
                    if (_calendarCommand.DeleteCalendar (calendar)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unknown Error Occured ");
                    }
                } else {
                    return StatusCode (404);
                }

            } catch (Exception) {
                return StatusCode (500, "Unknown Error Occured try again later");
            }

        }
    }

}