/*
 * @CreateTime: Aug 31, 2018 1:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 3:17 PM
 * @Description: Class Used to Fetch Organization data from datastore 
 */
using System.Collections.Generic;
using System.Linq;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Application.Organizations.Queries {
    public class OrganizationQuery : IOrganizationsQuery {
        private readonly IAccountingDatabaseService _database;
        private readonly IOrganizationFactory _factory;
        public OrganizationQuery (IAccountingDatabaseService database,
            IOrganizationFactory factory
        ) {
            _factory = factory;
            _database = database;

        }
        /// <summary>
        /// Gets all the organization record from the database
        /// </summary>
        /// <returns>IEnumerable<Organization> </returns>
        public IEnumerable<Organization> GetAllOrganizations () {
            return _database.Organization.ToList();
        }

        /// <summary>
        /// Gets a single organization recored based on its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Organization</returns>
        public Organization GetOrganizationById (uint id) {
            var organization = _database.Organization.Find(id);
            return organization;
        }

        /// <summary>
        /// Gets Single orfanization record based on its location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Organization</returns>
        public Organization GetOrganizationByLocation (string location) {
            var organization = _database.Organization.FirstOrDefault(org => org.Location == location);
            return organization;
        }
    }
}