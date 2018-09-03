using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;


namespace Smart_Accounting.API.Controllers.Calendarss
{
    [Route("api/calendars")]
    public class CalendarsController : Controller
    {

        private ICalendarPeriodsCommands _calendarCommand;
        private ICalendarPeriodQueries _calendarQuery;
        public CalendarsController(ICalendarPeriodQueries calendarQuery, ICalendarPeriodsCommands calendarCommand)
        {
            _calendarQuery = calendarQuery;
            _calendarCommand = calendarCommand;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllCalendarPeriod()
        {
            var calendars = _calendarQuery.GetAll();
            return Ok(calendars);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCalendarPeriodById(uint id)
        {
            var calendar = _calendarQuery.GetById(id);

            return Ok(calendar);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewCalendarPeriod([FromBody] NewCalendarModel newCalendar)
        {
            if(ModelState.IsValid){
                var calendar =  _calendarCommand.CreateCalendar(newCalendar);
                if(calendar != null){
                    return StatusCode(201, calendar);
                }else{
                    return StatusCode(500,"unkown error");
                }
            }else {
                return StatusCode (422,"required field are missing");
            }
           
            
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateCalendarPeriod(uint id, [FromBody] UpdateCalendarModel data)
        {
            if(ModelState.IsValid){
                var calendar = _calendarQuery.GetById(id);
                if(calendar != null){
                    var result = _calendarCommand.UpdateCalendar(calendar ,data);
                    if(result != false){
                        return StatusCode(204);
                    }else{
                        return StatusCode (500,"unkown error");
                    }
                }else{
                    return StatusCode (404);
                }
            }else{
                return  StatusCode (422,"required field is missing");
            }
        }
            
                
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCalendarPeriod(uint id) {
            
            var calendar = _calendarQuery.GetById(id);

                if(calendar != null) {
                    if(_calendarCommand.DeleteCalendar(calendar)) {
                        return StatusCode(204);
                    } else {
                        return StatusCode (500, "Unknown Error Occured ");
                    }
                } else {
                    return StatusCode(404);
                }
        }

    }
}