using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommands 
    {
        CalendarViewModel CreateCalendar  (CalendarPeriod newCalendar);
        bool  UpdateCalendar (CalendarPeriod calendar);
        bool DeleteCalendar (CalendarPeriod calender);
    }
}