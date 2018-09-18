using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommandsFactory 
    {
        CalendarPeriod NewCalendar (CalanderPeriodDto calendar);
        CalendarPeriod UpdateCalander(CalanderPeriodDto updatedCalander);
        CalendarViewModel CalendarView (CalendarPeriod calendar);
        //object UpdateCalander(CalendarPeriod old, UpdateCalendarModel updateCalendar);
    }
}