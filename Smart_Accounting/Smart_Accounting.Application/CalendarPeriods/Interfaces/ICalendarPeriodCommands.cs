using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommands 
    {
        void Create  (NewCalendarModel newCalendar);
        void Update ();
        void Delete (CalendarPeriod calender);
    }
}