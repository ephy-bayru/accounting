using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Interfaces {
    public interface IOrganizationCommands {
        OrganizationViewModel CreateOrganization (NewOrganizationModel newOrganization);
        bool UpdateOrganization (Organization organization,UpdatedOrganizationModel updatedOrganization);
        bool deleteOrganization (Organization organization);

    }
}