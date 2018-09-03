/*
 * @CreateTime: Aug 31, 2018 12:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By: undefined
 * @Last Modified Time: Aug 31, 2018 1:02 PM
 * @Description: OrganizationFactory, Provides Different Functions that 
 *  create or convert one kind of organization object to another type
 */


using System;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Factory {


    public class OrganizationFactory : IOrganizationFactory {

        /// <summary>
        /// converts new organization information passed from user to
        /// organization Domain object suitable for database persistence
        /// </summary>
        /// <param name="newOrganization">NewOrganizationModel</param>
        /// <returns>Organization</returns>
        public Organization OrganizationForCreation (NewOrganizationModel newOrganization) {

            var organization = new Organization ();

            organization.Name = newOrganization.Name;
            organization.Location = newOrganization.Location;
            organization.Tin = newOrganization.Tin;
            organization.DateAdded = DateTime.Now;
            organization.DateUpdated = DateTime.Now;
            return organization;

        }

        /// <summary>
        ///  Converts Updated organization information to Organization object
        /// suitable for database persistence
        /// </summary>
        /// <param name="organization">Organization</param>
        /// <param name="updatedOrganization">UpdatedOrganizationModel</param>
        /// <returns>Organization</returns>
        public Organization OrganizationForUpdate (Organization organization, UpdatedOrganizationModel org) {
            organization.Name = org.Name;
            organization.Id = org.Id;
            organization.Location = org.Location;
            organization.Tin = org.Tin;
            
            return organization;
        }

        /// <summary>
        /// convert organization object of the domain model to organization view object
        /// suitable for presentation
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        public OrganizationViewModel OrganizationView (Organization org) {

            var organization = new OrganizationViewModel ();

            organization.Id = org.Id;
            organization.Name = org.Name;
            organization.Location = org.Location;
            organization.Tin = org.Tin;
            organization.DateAdded = org.DateAdded;
            organization.DateUpdated = org.DateUpdated;
            

            return organization;
        }
    }
}