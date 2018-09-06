/*
 * @CreateTime: Aug 31, 2018 1:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 31, 2018 1:02 PM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Interfaces {
    public interface IOrganizationCommands {
        OrganizationViewModel CreateOrganization (NewOrganizationModel newOrganization);
        bool UpdateOrganization (Organization organization,UpdatedOrganizationModel updatedOrganization);
        bool deleteOrganization (Organization organization);

    }
}