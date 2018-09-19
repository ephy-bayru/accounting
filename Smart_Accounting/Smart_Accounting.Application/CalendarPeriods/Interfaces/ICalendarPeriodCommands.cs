/*
 * @CreateTime: Sep 14, 2018 4:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 14, 2018 4:06 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces {

    public interface ICalendarPeriodsCommands 
    {
        IEnumerable<CalendarViewModel> CreateCalendar  (IEnumerable<CalendarPeriod> newCalendar);
        bool  UpdateCalendar (CalendarPeriod calendar);
        bool DeleteCalendar (CalendarPeriod calender);
    }
}