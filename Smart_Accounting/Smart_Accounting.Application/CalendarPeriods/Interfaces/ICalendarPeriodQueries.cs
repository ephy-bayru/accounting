using System;
using System.Collections.Generic;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces

{
    public interface ICalendarPeriodQueries {
        CalendarPeriod GetById (uint id);
        List<CalendarPeriod> GetAll ();
        bool IsStartDateOveraped (DateTime startDate);
        bool IsEndDateOveraped (DateTime endDate);
        CalendarPeriod getActivePeriod ();
        uint getActivePeriodId ();
        IEnumerable<CalanderPeriodListView> GetOpenPeriods();
    }
}