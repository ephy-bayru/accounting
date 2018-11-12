/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 10:19 AM
 * @Description: Modify Here, Please 
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CalendarsController> _logger;

        public CalendarsController (ICalendarPeriodQueries calendarQuery,
            ICalendarPeriodsCommands calendarCommand,
            ICalendarPeriodsCommandsFactory factory,
            IResponseFactory response,
            ILogger<CalendarsController> logger) {
            _calendarQuery = calendarQuery;
            _calendarCommand = calendarCommand;
            _factory = factory;
            _responseFactory = response;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        public IActionResult GetAllCalendarPeriod (string type = "ALL") {

            switch (type.ToUpper ()) {

                case "ACTIVE":
                    var activeCalander = _calendarQuery.getActivePeriod ();
                    return StatusCode (200, activeCalander);
                case "OPEN":
                    var calanders = _calendarQuery.GetOpenPeriods ();
                    return StatusCode (200, calanders);
                default:
                    var allCalanders = _calendarQuery.GetAll ();
                    var respone = _responseFactory.Create (allCalanders);
                    return StatusCode (200, respone);

            }
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

        [HttpPut("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)] // Locked (The resource that is being accessed is locked) 
        [ProducesResponseType (500)]
        public ActionResult UpdateCalendarPeriod (uint id, [FromBody] UpdatedCalanderDto data) {

            if (ModelState.IsValid) {

                id = (id == 0) ? data.id : id;

                var calendar = _calendarQuery.GetById (id);
                //  check if calander with the specified id exists
                if (calendar == null) {
                    return StatusCode(404);
                } 

                    var calanerFactory = _factory.UpdateCalander (calendar, data);

                    var result = _calendarCommand.UpdateCalendar (calanerFactory);

                    // convert calander data passed from the user to calanderperiod Object

                    if (result != false) {
                        return StatusCode (204); // when updated Successfully

                    } else {

                        return StatusCode (500, "unkown error");
                    }
    
            } else {
                return StatusCode (422, "required field is missing");
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (423)] // Locked (The resource that is being accessed is locked) 
        [ProducesResponseType (500)]
        public IActionResult DeleteCalendarPeriod (uint id) {

            try {
                var calendar = _calendarQuery.GetById (id);
                // Get the Calander Specified by the Id

                if (calendar == null) {
                    return StatusCode (404); // if calander exists
                }

                var result = _calendarCommand.DeleteCalendar (calendar);
                if (result == true) {
                    return StatusCode (204);
                } else {
                    return StatusCode (500, "Unknown Error Occured ");
                }

            } catch (DbUpdateException e) {
                _logger.LogInformation (423, e, e.Message);
                return StatusCode (423, $"Selected Period with id: {id} Can not be deleted because it has been used on other parts of the system  ");
            } catch (Exception e) {
                _logger.LogError (500, e, e.Message);
                return StatusCode (500, "Unknown Error Occured, Please Try again later ");
            }

        }
    }

}