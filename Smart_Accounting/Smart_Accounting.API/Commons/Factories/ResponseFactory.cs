using System.Collections.Generic;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Oranizations;

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

        public ResponseFormat CreateOrganizationResponse(List<OrganizationViewModel> organizations)
        {
            ResponseFormat format = new ResponseFormat() {
                Items = organizations,
                Count = organizations.Count
            };

            return format;
        }
    }
}