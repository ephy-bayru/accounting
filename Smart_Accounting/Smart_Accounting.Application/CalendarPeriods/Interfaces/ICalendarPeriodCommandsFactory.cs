using System.Collections.Generic;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommandsFactory 
    {
        IEnumerable<CalendarPeriod> NewCalendar (IEnumerable<CalanderPeriodDto> calendar);
        CalendarPeriod UpdateCalander(CalanderPeriodDto updatedCalander);
        IEnumerable<CalendarViewModel> CalendarView (IEnumerable<CalendarPeriod> calendar);
        //object UpdateCalander(CalendarPeriod old, UpdateCalendarModel updateCalendar);
    }
}