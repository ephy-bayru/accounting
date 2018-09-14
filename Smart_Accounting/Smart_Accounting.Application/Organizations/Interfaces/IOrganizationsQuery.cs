/*
 * @CreateTime: Aug 31, 2018 1:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 11:57 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Application.Models;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Interfaces {
    public interface IOrganizationsQuery {
        Organization GetOrganizationById (uint id);
        Organization GetOrganizationByLocation (string id);
        IEnumerable<Organization> GetAllOrganizations (string filter, string orderby, int top, int limit);
    }
}