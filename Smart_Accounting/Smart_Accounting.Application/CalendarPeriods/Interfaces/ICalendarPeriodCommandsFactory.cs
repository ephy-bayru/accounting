using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommandsFactory 
    {
        CalendarPeriod NewCalendar (NewCalendarModel calendar);
        CalendarPeriod UpdateCalander(CalendarPeriod CalendarPeriods,UpdateCalendarModel calendar);
        CalendarViewModel CalendarView (CalendarPeriod calendar);
        //object UpdateCalander(CalendarPeriod old, UpdateCalendarModel updateCalendar);
    }
}