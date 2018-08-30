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
        public IEnumerable<Organization> GetAllOrganizations () {
            //TODO GetAllOrganization Function in OrganizationQuery Class
            return _database.Organization.ToList();
        }

        public Organization GetOrganizationById (uint id) {
            var organization = _database.Organization.Find(id);
            return organization;
        }

        public Organization GetOrganizationByLocation (uint id) {
            //TODO GetOrganizationByLocation Method in Organization Query
            throw new System.NotImplementedException ();
        }
    }
}