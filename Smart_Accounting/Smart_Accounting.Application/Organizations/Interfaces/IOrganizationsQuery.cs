/*
 * @CreateTime: Aug 31, 2018 1:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By: undefined
 * @Last Modified Time: Aug 31, 2018 1:03 PM
 * @Description: Modify Here, Please 
 */
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