using System.Collections.Generic;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.API.Commons.Factories {
    public interface IResponseFactory {
        ResponseFormat Create (List<CalendarPeriod> calander);
    }
}