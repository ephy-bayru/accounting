using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;


namespace Smart_Accounting.API.Controllers.CalendarPeriods
{
    [Route("api/CalendarPeriods")]

    public class CalendarPeriodsController : Controller
{
   
    private ICalendarPeriodsCommands _calendarCommand;
    private ICalendarPeriodQueries _calendarQuery;
    public CalendarPeriodsController(ICalendarPeriodQueries calendarQuery,ICalendarPeriodsCommands calendarCommand)
    {
        _calendarQuery = calendarQuery;
        _calendarCommand = calendarCommand;
    }

  
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllCalendarPeriod() {
            var calendar =  _calendarQuery.GetAll();
            
            return Ok(calendar);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCalendarPeriodById(uint id) {
            var calendar = _calendarQuery.GetById(id);
            
            return Ok(calendar);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewCalendarPeriod([FromBody] NewCalendarModel NewCalendar) {
            _calendarCommand.Create(NewCalendar);
            return StatusCode(201, NewCalendar);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateCalendarPeriod(uint id,[FromBody] NewCalendarModel NewCalendar) {
            _calendarCommand.Create(NewCalendar);
            return Ok(NewCalendar);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult DeleteCalendarPeriod(uint id) {

            var exists = _calendarQuery.GetById(id);

            if (exists == null) {
                return NotFound();
            }
            _calendarCommand.Delete(exists);

            return NoContent();
            
        }
       
    }
}