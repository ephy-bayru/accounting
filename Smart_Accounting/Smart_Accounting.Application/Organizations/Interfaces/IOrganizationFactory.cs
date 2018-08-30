using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Interfaces {
    public interface IOrganizationFactory {
        Organization OrganizationForCreation (NewOrganizationModel organization);
        Organization OrganizationForCreation (UpdatedOrganizationModel organization);
        OrganizationViewModel OrganizationView (Organization organization);
    }
}