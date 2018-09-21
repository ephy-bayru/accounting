using System.Collections.Generic;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.API.Commons.Factories
{
    public class ResponseFactory : IResponseFactory
    {
        public ResponseFormat Create(List<CalendarPeriod> calander)
        {
            ResponseFormat format = new ResponseFormat() {
                Items = calander,
                Count = calander.Count
            };

            return format;
        }

    }
}