/*
 * @CreateTime: Nov 9, 2018 4:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 9:58 AM
 * @Description: Converts Calendar Period Dto To Calendar period Domain Object 
 *  and vice versa
 */
using System.Collections.Generic;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Factorys {
    public class CalendarPeriodCommandsFactorys : ICalendarPeriodsCommandsFactory {

        public IEnumerable<CalendarViewModel> CalendarView (IEnumerable<CalendarPeriod> calendar) {
            List<CalendarViewModel> calendars = new List<CalendarViewModel> ();

            foreach (var item in calendar) {
                CalendarViewModel cal = new CalendarViewModel () {
                    Id = item.Id,
                    Start = item.Start,
                    End = item.End,
                    IsBegining = (item.IsBegining == 1) ? true : false,
                    Active = (item.Active == 1) ? true : false
                };

                calendars.Add (cal);
            }

            return calendars;
        }

        public IEnumerable<CalendarPeriod> NewCalendar (IEnumerable<NewCalendarPeriodDto> calendar) {
            List<CalendarPeriod> calendars = new List<CalendarPeriod> ();

            foreach (var item in calendar) {
                CalendarPeriod cal = new CalendarPeriod ();
                cal.Start = item.Start;
                cal.End = item.End;
                cal.Active = item.active;
                cal.IsBegining = item.isBegining;
                calendars.Add (cal);
            }

            return calendars;

        }

        public CalendarPeriod UpdateCalander (CalendarPeriod oldCalendar, UpdatedCalanderDto calendar) {
            oldCalendar.Start = calendar.Start;
            oldCalendar.End = calendar.End;
            oldCalendar.IsBegining = calendar.isBegining;
            oldCalendar.Active = calendar.active;
            return oldCalendar;

        }
    }
}