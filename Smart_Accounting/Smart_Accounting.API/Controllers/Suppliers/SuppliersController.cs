using System;
using Smart_Accounting.Application.Supplier.Commands;
using Smart_Accounting.Application.Supplier.Commands.Factories;
using Smart_Accounting.Application.Supplier.Factories;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Domain.Supplier;
// using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Smart_Accounting.API.Controllers.Suppliers {

    [Route ("api/suppliers")]
    [Produces ("application/json")]
    [ProducesResponseType (typeof (List<string>), 400)]
    public class SuppliersController : Controller {
        // private readonly ILogger<SuppliersController> _logger;
        private readonly ISuppliersFactory _supplierFactory;
        private ISupplierCommandes _supplierCommands;
        private ISuppliersQuery _supplierQuery;
        private readonly IResponseFactory _response;
        public SuppliersController (
            ISuppliersQuery supplierQuery,
            ISupplierCommandes supplierCommands,
            //   ILogger<SuppliersController> logger,
            ISuppliersFactory supplierFactory,
            IResponseFactory response
        ) {
            _supplierQuery = supplierQuery;
            _supplierCommands = supplierCommands;
            // _logger = logger;
            _supplierFactory = supplierFactory;
            _response = response;
        }

        [HttpGet]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult GetAllCustomers () {
            var suppliers = _supplierQuery.GetAll ();
            var supplierView = _supplierFactory.createSupplierView (suppliers);
            var response = _response.CreateSupplierResponse (supplierView);
            return StatusCode (200, response);

        }

        [HttpGet ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult GetSupplierById (uint id) {
            try {
                var supplier = _supplierQuery.GetById (id);

                if (supplier == null) {
                    // _logger.LogError($"supplier with id: {id}, hasn't been found.");
                    return NotFound ($"supplier with id: {id}, hasn't been found.");
                } else {
                    // _logger.LogInformation($"Returned supplier with id: {id}");
                    return StatusCode (201, supplier);
                }
            } catch (Exception x) {
                // _logger.LogError($"sonething went wrong: {x.Message}");
                return StatusCode (500, $"something went wrong: {x.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult CreateNewSupplierr ([FromBody] NewSupplierModel newSupplier) {

            if (newSupplier == null) {
                // _logger.LogError("Empty supplier data");
                return BadRequest ("Supplier data is empty");
            }
            if (!ModelState.IsValid) {
                // // _logger.LogError("invalid data sent from users");
                // ModelState.AddModelError("Registration error", "Invalid Suppliers form Data");
                return StatusCode (422, "Invalid supplier data model sent from users");
            }
            var supp = _supplierFactory.CreateNewSupplier (newSupplier);
            _supplierCommands.Create (supp);
            // _logger.LogInformation("successfully registered new supplier!");
            return StatusCode (201, supp);

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult UpdateSupplier (uint id, [FromBody] UpdateSupplierModel updateSupplier) {
            try {
                if (updateSupplier == null) {
                    return BadRequest ();
                }

                if (!ModelState.IsValid) {
                    return StatusCode (422);
                }
                var currentSupplier = _supplierQuery.GetById (id);
                if (currentSupplier == null) {
                    return NotFound ();
                }
                _supplierCommands.Update (currentSupplier, updateSupplier);
                return StatusCode (204);

            } catch (Exception x) {
                // _logger.LogError($"something went wrong: {x.Message}");
                return StatusCode (500, $"something went wrong: {x.Message}");

            }
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult DeleteSuppler (uint id) {
            try {
                var supplier = _supplierQuery.GetById (id);
                if (supplier == null) {
                    // _logger.LogError($"supplier with id: {id}, not found.");
                    return NotFound ($"supplier with id: {id}, not found.");
                }
                _supplierCommands.Delete (supplier);
                return NoContent ();

            } catch (Exception x) {
                // _logger.LogError($"Something went wrong: {x.Message}");
                return StatusCode (500, $"Something went wrong: {x.Message}");
            }

        }

    }

}