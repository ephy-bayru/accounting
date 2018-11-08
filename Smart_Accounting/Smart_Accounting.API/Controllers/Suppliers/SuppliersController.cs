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
// HTTP GET
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── I ──────────
//   :::::: S E N D I N G   H T T P   G E T   R E Q U E S T   T O   R E T R I V E   A L L   S U P P L I E R S : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// RETRIVES ALL SUPPLIERS FROM DB

        [HttpGet]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult GetAllSuppliers () {
            var suppliers = _supplierQuery.GetAll ();
            var supplierView = _supplierFactory.createSupplierView (suppliers);
            var response = _response.CreateSupplierResponse (supplierView);
            return StatusCode (200, response);

        }
// HTTP GET(ID)
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── II ──────────
//   :::::: S E N D I N G   H T T P   G E T   R E Q U E S T   T O   R E T R I V E   A   S I N G L E   S U P P L I E R : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// RETRIVES A SINGLE SUPPLIER

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
// HTTP POST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── III ──────────
//   :::::: S E N D I N G   H T T P   P O S T   R E Q U E S T   T O   A D D   A   N E W   S U P P L I E R : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// ADDS NEW SUPPLIER

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
                return StatusCode (422, ModelState);
            }
            var supp = _supplierFactory.CreateNewSupplier (newSupplier);
            _supplierCommands.Create (supp);
            // _logger.LogInformation("successfully registered new supplier!");
            return StatusCode (201, supp);

        }
// HTTP PUT(ID)
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── IV ──────────
//   :::::: S E N D I N G   H T T P   P U T   R E Q U E S T   T O   U P D A T E   A N   E X I S T I N G   S U P P L I E R   D A T A : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// UPDATES AN EXISTING SUPPLIER

        [HttpPut ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult UpdateSupplier (uint id, [FromBody] UpdateSupplierModel updateSupplier) {
            try {
                if (updateSupplier == null) {
                    return BadRequest ();
                }

                if (!ModelState.IsValid) {
                    return StatusCode (422, ModelState);
                }
                var currentSupplier = _supplierQuery.GetById (id);
                if (currentSupplier == null) {
                    return NotFound ();
                }

                updateSupplier.id = id;
                var supplier = _supplierFactory.UpdatedSupplier(updateSupplier);
                var result = _supplierCommands.Update(supplier, updateSupplier);

                if(result == true) {
                        return StatusCode (204);
                } else{
                return StatusCode (500, $"something went wrong");    
                }
                
            } catch (Exception x) {
                // _logger.LogError($"something went wrong: {x.Message}");
                return StatusCode (500, $"something went wrong: {x.Message}");

            }
        }
        
// HTTP DELETE(ID)
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── V ──────────
//   :::::: S E N D I N G   H T T P   D E L E T E   R E Q U E S T   T O   D E L E T E   A N   E X I S T I N G   S U P P L I E R : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
//

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