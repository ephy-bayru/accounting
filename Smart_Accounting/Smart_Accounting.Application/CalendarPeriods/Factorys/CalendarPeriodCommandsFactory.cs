
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Factorys
{
    public class CalendarPeriodCommandsFactorys : ICalendarPeriodsCommandsFactory
    {
        
        

        public CalendarViewModel CalendarView(CalendarPeriod calendar)
        {
            var calendars = new CalendarViewModel ();

            calendar.Id = calendars.Id;
            calendar.Start = calendars.Start;
            calendar.End = calendars.End;

            return calendars;
        }

        public CalendarPeriod NewCalendar(NewCalendarModel calendar)
        {
            var calendars = new CalendarPeriod ();

            calendars.Start = calendar.Start;
            calendars.End = calendar.End;

            return calendars;
           
        }
        

      

    
        public CalendarPeriod UpdateCalander(CalendarPeriod CalendarPeriods,UpdateCalendarModel calendar)
        {
            CalendarPeriods.Id = calendar.Id;
            CalendarPeriods.Start = calendar.Start;
            CalendarPeriods.End = calendar.End;

            return CalendarPeriods;
            
        }
    }
}