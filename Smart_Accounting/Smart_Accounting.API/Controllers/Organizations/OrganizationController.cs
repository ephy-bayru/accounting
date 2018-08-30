using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;

namespace Smart_Accounting.API.Controllers.Organizations {

    [Route ("api/organizations")]
    public class OrganizationController : Controller {
        private readonly IOrganizationCommands _command;
        private readonly IOrganizationsQuery _query;
        private readonly IOrganizationFactory _factory;
        public OrganizationController (IOrganizationCommands command,
            IOrganizationsQuery query,
            IOrganizationFactory factory) {
            _factory = factory;
            _command = command;
            _query = query;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (OrganizationViewModel))]
        public IActionResult GetAllOrganizations () {
            var organizations = _query.GetAllOrganizations ();

            IList<OrganizationViewModel> organizationList = new List<OrganizationViewModel>();

            foreach (var item in organizations)
            {
                var x = _factory.OrganizationView(item);
                organizationList.Add(x);
                
                
            }

            return StatusCode (200,  organizationList);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (OrganizationViewModel))]
        [ProducesResponseType (404)]
        public IActionResult GetOrganizationById (uint id) {
            var organization = _query.GetOrganizationById (id);
            
            if (organization != null) {
                var organizationView = _factory.OrganizationView(organization);
                return StatusCode (200, organizationView);
            } else {
                return StatusCode (404);
            }

        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (OrganizationViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddNewOrganization ([FromBody] NewOrganizationModel newOrganization) {
            if (ModelState.IsValid) {
                var organization = _command.CreateOrganization (newOrganization);
                if (organization != null) {
                    return StatusCode (201, organization);
                } else {
                    return StatusCode (500, "Unknown Error Occured While Processing Data Try Again Later");
                }

            } else {
                return StatusCode (422, "One or More Required Fields Missing");
            }

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult UpdateOrganization (uint id, [FromBody] UpdatedOrganizationModel data) {

            if (ModelState.IsValid) {

                var organization = _query.GetOrganizationById (id);

                if (organization != null) {
                    var result = _command.UpdateOrganization (organization, data);

                    if (result != false) {
                        return StatusCode (204);

                    } else {
                        return StatusCode (500, "Unknown Error Occured While Processing Data Try Again Later");
                    }

                } else {
                    return StatusCode (404);
                }

            } else {
                return StatusCode (422, "One or More Required Fields Missing");
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteOrganization(uint id) {
            var organization = _query.GetOrganizationById(id);

                if(organization != null) {
                    if(_command.deleteOrganization(organization)) {
                        return StatusCode(204);
                    } else {
                        return StatusCode (500, "Unknown Error Occured While Processing Data Try Again Later");
                    }
                } else {
                    return StatusCode(404);
                }
        }

    }
}