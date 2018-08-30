using System;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Factory {
    public class OrganizationFactory : IOrganizationFactory {
        public Organization OrganizationForCreation (NewOrganizationModel org) {

            var organization = new Organization ();

            organization.Name = org.Name;
            organization.Location = org.Location;
            organization.Tin = org.Tin;
            organization.DateAdded = DateTime.Now;
            organization.DateUpdated = DateTime.Now;
            return organization;

        }

        public Organization OrganizationForUpdate (Organization organization, UpdatedOrganizationModel org) {
            organization.Name = org.Name;
            organization.Id = org.Id;
            organization.Location = org.Location;
            organization.Tin = org.Tin;

            return organization;
        }

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