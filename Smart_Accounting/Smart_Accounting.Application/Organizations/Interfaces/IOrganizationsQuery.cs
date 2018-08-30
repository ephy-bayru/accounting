using System.Collections.Generic;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Interfaces {
    public interface IOrganizationsQuery {
        Organization GetOrganizationById (uint id);
        Organization GetOrganizationByLocation (uint id);
        IEnumerable<Organization> GetAllOrganizations ();
    }
}