using System.Collections.Generic;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.API.Commons.Factories {
    public interface IResponseFactory {
        ResponseFormat Create (List<CalendarPeriod> calander);
        ResponseFormat CreateOrganizationResponse (List<OrganizationViewModel> calander);
    }
}