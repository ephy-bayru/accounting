using System.Collections.Generic;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.CalendarPeriods.Interfaces

{
    public interface ICalendarPeriodQueries
    {
        CalendarPeriod GetById(uint Id);

        IEnumerable<CalendarPeriod> GetAll();
    }
}