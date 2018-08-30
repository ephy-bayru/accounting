using System.Collections.Generic;
using Smart_Accounting.Application.Organizations.Models;

namespace Smart_Accounting.Application.Organizations.Interfaces {
    public interface IOrganizationsQuery {
        OrganizationViewModel GetOrganizationById (uint id);
        OrganizationViewModel GetOrganizationByLocation (uint id);
        IEnumerable<OrganizationViewModel> GetAllOrganizations ();
    }
}