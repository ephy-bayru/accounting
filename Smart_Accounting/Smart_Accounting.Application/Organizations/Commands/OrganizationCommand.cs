/*
 * @CreateTime: Aug 31, 2018 12:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 4, 2018 4:58 PM
 * @Description: OrganizationCommand, provides different data manipulation functions 
 *               on Organization Domain Object
 */

using System;
using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Commands {

    public class OrganizationCommand : IOrganizationCommands {

        //factory class interface that will create deferent organization object types
        private readonly IOrganizationFactory _factory; 
        //main interface for database access
        private readonly IAccountingDatabaseService _database; 
        public OrganizationCommand (
            IOrganizationFactory factory,
            IAccountingDatabaseService database) {
            _database = database;
            _factory = factory;
        }

        /// <summary>
        /// Used to create new instance of organization object
        /// </summary>
        /// <param name="newOrganization">NewOrganizationModel</param>
        /// <returns>OrganizationViewModel</returns>
        public OrganizationViewModel CreateOrganization (NewOrganizationModel newOrganization) {
            try {
                var organization = _factory.OrganizationForCreation (newOrganization);

                _database.Organization.Add (organization);

                _database.Save ();

                return _factory.OrganizationView (organization);
            } catch (Exception) {
                return null;
            }

        }
        /// <summary>
        /// Deletes Single organization record
        /// </summary>
        /// <param name="organization">Organization</param>
        /// <returns>bool</returns>
        public bool deleteOrganization (Organization organization) {
            try {
                _database.Organization.Remove (organization);
                _database.Save ();
                return true;
            } catch (Exception) {
                return false;
            }

        }

        /// <summary>
        /// Updates Single organization Record
        /// </summary>
        /// <param name="currentOrganization">Organization</param>
        /// <param name="updatedOrganization">UpdatedOrganizationModel</param>
        /// <returns>bool</returns>
        public bool UpdateOrganization (Organization currentOrganization, UpdatedOrganizationModel updatedOrganization) {
            try {

                var organization = _factory.OrganizationForUpdate (currentOrganization, updatedOrganization);

                _database.Organization.Update (organization);
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }

        }
    }
}