/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 24, 2018 11:43 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.API.Commons.Models;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.API.Controllers.Organizations {

    [Route ("api/organizations")]
    public class OrganizationController : Controller {
        private readonly IOrganizationCommands _command;
        private readonly IOrganizationsQuery _query;
        private readonly IResponseFactory _response;
        private readonly IOrganizationFactory _factory;
        public OrganizationController (IOrganizationCommands command,
            IOrganizationsQuery query,
            IOrganizationFactory factory,
            IResponseFactory response) {
            _factory = factory;
            _command = command;
            _query = query;
            _response = response;
        }
        /// <summary>
        /// gets all records of organization in the databse (url=api/organizations)
        /// </summary>
        /// <returns>List<OrganizationViewModel></returns>
        [HttpGet]
        [ProducesResponseType (200, Type = typeof (OrganizationViewModel))]
        public IActionResult GetAllOrganizations (
            [FromQuery (Name = "$inlineCount")] string filter = "all", [FromQuery (Name = "$orderby")] string orderby = "mike", [FromQuery (Name = "$skip")] int skip = 0, [FromQuery (Name = "$orderby")] int top = 10) {
            try {

                var organizations = _query.GetAllOrganizations (filter, orderby, skip, top);

                IList<OrganizationViewModel> organizationList = new List<OrganizationViewModel> ();

                // convert each organization object to organization view model
                foreach (var item in organizations) {

                    var x = _factory.OrganizationView (item);
                    organizationList.Add (x);

                }

                var response = _response.CreateOrganizationResponse ((List<OrganizationViewModel>) organizationList);

                return StatusCode (200, response);

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

        /// <summary>
        /// Gets single record of organization based on its Id (url = api/organizations/:id)
        /// </summary>
        /// <param name="id">uint</param>
        /// <returns>organizationViewModel</returns>
        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (OrganizationViewModel))]
        [ProducesResponseType (404)]
        public IActionResult GetOrganizationById (uint id) {

            try {

                var organization = _query.GetOrganizationById (id);

                if (organization != null) {
                    var organizationView = _factory.OrganizationView (organization);
                    return StatusCode (200, organizationView);
                } else {
                    return StatusCode (404);
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        /// <summary>
        /// Get single record of organization based on its location reference (Url = api/organizations/location/:locationString)
        /// </summary>
        /// <param name="location">string</param>
        /// <returns>OrganizationViewModel</returns>
        [HttpGet ("location/{location}")]
        [ProducesResponseType (200, Type = typeof (OrganizationViewModel))]
        [ProducesResponseType (404)]
        public IActionResult GetOrganizationByLocation (string location) {

            try {

                var organization = _query.GetOrganizationByLocation (location);

                if (organization != null) {
                    var organizationView = _factory.OrganizationView (organization);
                    return StatusCode (200, organizationView);
                } else {
                    return StatusCode (404);
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        /// <summary>
        /// Creates new instance of organization and returns the new record (Url = api/organizations)
        /// </summary>
        /// <param name="newOrganization">NewOrganizationModel</param>
        /// <returns>OrganizationViewModel</returns>
        [HttpPost]
        [ProducesResponseType (201, Type = typeof (OrganizationViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddNewOrganization ([FromBody] NewOrganizationModel newOrganization) {

            try {

                if (ModelState.IsValid && newOrganization != null) {
                    var organization = _command.CreateOrganization (newOrganization);
                    if (organization != null) {
                        return StatusCode (201, organization);
                    } else {
                        return StatusCode (422);
                    }

                } else {
                    return StatusCode (422, "One or More Required Fields Missing");
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        /// <summary>
        /// Updates single instance organization record based on its Id (Url = api/organization/:organizationId)
        /// id is pased as part of the url
        /// </summary>
        /// <param name="id">uint</param>
        /// <param name="data">UpdatedOrganizationModel</param>
        /// <returns>bool</returns>
        [HttpPut ("{id}")]
        [ProducesResponseType (204, Type = typeof (bool))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult UpdateOrganization (uint id, [FromBody] UpdatedOrganizationModel data) {

            try {

                if (ModelState.IsValid) {

                    var organization = _query.GetOrganizationById (id);

                    if (organization != null) {
                        var result = _command.UpdateOrganization (organization, data);

                        if (result != false) {
                            return StatusCode (204);

                        } else {
                            return StatusCode (422);
                        }

                    } else {
                        return StatusCode (404);
                    }

                } else {
                    return StatusCode (422, "One or More Required Fields Missing");
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        /// <summary>
        /// Updates single instance of organization based on the id found in the http request body (url = api/organization)
        /// </summary>
        /// <param name="data">UpdatedOrganizationModel</param>
        /// <returns>bool</returns>
        [HttpPut]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult UpdateOrganization ([FromBody] UpdatedOrganizationModel data) {

            try {

                if (ModelState.IsValid) {

                    var organization = _query.GetOrganizationById (data.id);

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

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        /// <summary>
        /// Deletes single instance of organization record based on the id passed as part of the url (url = api/organizations )
        /// </summary>
        /// <param name="id">uint</param>
        /// <returns>bool</returns>
        [HttpDelete ("{id}")]
        [ProducesResponseType (204, Type = typeof (bool))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteOrganization (uint id) {

            try {

                var organization = _query.GetOrganizationById (id);

                if (organization != null) {

                    if (_command.deleteOrganization (organization)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unknown Error Occured While Processing Data Try Again Later");
                    }
                } else {
                    return StatusCode (404);
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }
        }

    }
}