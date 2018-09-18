using System.Collections.Generic;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain;
using System;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces

{
    public interface ICalendarPeriodQueries
    {
        CalendarPeriod GetById(uint id);

        IEnumerable<CalendarPeriod> GetAll();
         bool IsStartDateOveraped(DateTime startDate);
        bool IsEndDateOveraped(DateTime endDate);
    }
}