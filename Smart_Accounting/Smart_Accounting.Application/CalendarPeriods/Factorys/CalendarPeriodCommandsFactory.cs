
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Factorys
{
    public class CalendarPeriodCommandsFactorys : ICalendarPeriodsCommandsFactory
    {
        public CalendarPeriod NewCalendar(NewCalendarModel data)
        {
            var calendar = new CalendarPeriod();
            calendar.Start = data.Start;
            calendar.End = data.End;
            return calendar;
        }

        public CalendarPeriod UpdateCalander()
        {
            throw new System.NotImplementedException();
        }
    }      

}