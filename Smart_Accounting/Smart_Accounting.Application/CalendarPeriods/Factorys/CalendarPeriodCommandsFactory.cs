using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Factorys {
    public class CalendarPeriodCommandsFactorys : ICalendarPeriodsCommandsFactory {

        public CalendarViewModel CalendarView (CalendarPeriod calendar) {
            var calendars = new CalendarViewModel ();

            calendar.Id = calendars.Id;
            calendar.Start = calendars.Start;
            calendar.End = calendars.End;

            return calendars;
        }

        public CalendarPeriod NewCalendar (CalanderPeriodDto calendar) {
            var calendars = new CalendarPeriod ();
            calendars.Id = (calendar.id > 0) ? calendar.id : 0;
            calendars.Start = calendar.Start;
            calendars.End = calendar.End;

            return calendars;

        }

        public CalendarPeriod UpdateCalander (CalanderPeriodDto calendar) {
            CalendarPeriod calanderPeriod = new CalendarPeriod ();
            calanderPeriod.Id = calendar.id;
            calanderPeriod.Start = calendar.Start;
            calanderPeriod.End = calendar.End;

            return calanderPeriod;

        }
    }
}