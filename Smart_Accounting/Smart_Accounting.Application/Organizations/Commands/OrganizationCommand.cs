using System;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Commands {
    public class OrganizationCommand : IOrganizationCommands {

        private readonly IOrganizationFactory _factory;
        private readonly IAccountingDatabaseService _database;
        public OrganizationCommand (
                                    IOrganizationFactory factory, 
                                    IAccountingDatabaseService database) {
                _database = database;
                _factory = factory;
        }
        public OrganizationViewModel CreateOrganization (NewOrganizationModel newOrganization) {
            try {
                        //convert the new organization data passed to organization object
                    var organization = _factory.OrganizationForCreation(newOrganization);
                    _database.Organization.Add(organization);           //add to database
                    _database.Save();   // save new organization in the database
                
                    //return new organization object to organization view object
                return _factory.OrganizationView(organization);                                                    
            } catch(Exception) {
                return null; 
            }
        }

        public bool deleteOrganization (Organization organization) {
            //TODO DeateOrganization  in OrganizationCommand Class
            throw new System.NotImplementedException ();
        }

        public bool UpdateOrganization (UpdatedOrganizationModel updatedOrganization) {
            //TODO UpdateOrganization in Organization Class
            throw new System.NotImplementedException ();
        }
    }
}