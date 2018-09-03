using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommandsFactory 
    {
        CalendarPeriod NewCalendar (NewCalendarModel data);

        CalendarPeriod UpdateCalander();
    }
}