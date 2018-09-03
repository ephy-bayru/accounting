using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommands 
    {
        CalendarViewModel CreateCalendar  (NewCalendarModel newCalendar);
        bool  UpdateCalendar (CalendarPeriod calender,UpdateCalendarModel UpdateCalendar);
        bool DeleteCalendar (CalendarPeriod calender);
    }
}