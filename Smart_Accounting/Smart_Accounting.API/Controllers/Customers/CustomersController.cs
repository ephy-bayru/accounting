/*
 * @CreateTime: Oct 9, 2018 9:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 3:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.Customers.Commands;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Factories;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.API.Controllers.Customers {

    [Route ("api/customers")]
    public class CustomersController : Controller {
        // private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerFactory _customerFactory;
        private ICustomerCommands _customerCommands;
        private ICustomerQuery _customerQuery;
        private readonly IResponseFactory _response;
        public CustomersController (
            ICustomerQuery customerQuery,
            ICustomerCommands customerCommand,
            // ILogger<CustomersController> logger,
            ICustomerFactory customerFactory,
            IResponseFactory response
        ) {
            _customerQuery = customerQuery;
            _customerCommands = customerCommand;
            // _logger = logger;
            _customerFactory = customerFactory;
            _response = response;
        }
// HTTP GET
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── I ──────────
//   :::::: S E N D I N G   H T T P G E T   R E Q U E S T   T O   F E E T C H   A L L   C U S T O M E R S   F R O M   D A T A B A S E : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// RETRIVES ALL CUSTOMERS FROM DATABASE

        [HttpGet]
        [ProducesResponseType (200)]
        public IActionResult GetAllCustomers () {
            var customers = _customerQuery.GetAll ();
            var customerView = _customerFactory.createCustomerView (customers);
            var response = _response.CreateCustomerResonse (customerView);
            return StatusCode (200, response);

        }
// HTTP GET
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── II ──────────
//   :::::: S E N D I N G   H T T P G E T   R E Q U E S T   T O   F E T C H   A   S I N G L E   C U S T O M E R   F R O M   D A T A B E S E : :  :   :    :     :        :          :
// ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// RETRIVE A SINGLE USER FROM A CUSTOMERS DATABASE

        [HttpGet ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult GetCustomerById (uint id) {
            try {
                var customers = _customerQuery.GetById (id);

                if (customers == null) {
                    return NotFound ($"customer with id: {id}, hasn't been found.");
                } else {
                    return Ok (customers);
                }
            } catch (Exception x) {
                return StatusCode (500, $"something went wrong: {x.Message}");
            }
        }
// HTTP POST
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── III ──────────
//   :::::: S E N D I N G   H T T P   P O S T   R E Q U E S T   T O   A D D   A   N E W   C U S T O M E R   T O   D A T A B A S E : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// ADDS A NEW CUSTOMER TO THE DATABASE


        [HttpPost]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult CreateNewCustomer ([FromBody] NewCustomerModel newCustomer) {
                if (newCustomer == null) {
                    return BadRequest ("Empty customers data");
                }
                if (!ModelState.IsValid) {
                    return StatusCode (422, "Invalid customer data model sent from users");
                }

                var customer = _customerFactory.NewCustomerAccount (newCustomer);
                var result = _customerCommands.Create (newCustomer);

                if (customer == null) {
                    return StatusCode (500, $"internal server error");
                } else {
                    return StatusCode (201, customer);
                }

        }
// HTTP PUT
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── IV ──────────
//   :::::: S E N D I N G   H T T P   P U T   R E Q U E S T   T O   U P D A T E   A N   E X I S T I N G   C U S T O M E R : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// UPDATES AN EXISTING CUSTOMER


        [HttpPut ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult UpdateCustomer (uint id, [FromBody] UpdateCustomerModel updateCustomer) {
            try {
                if (updateCustomer == null) {
                    return BadRequest ();
                }

                if (!ModelState.IsValid) {
                    return StatusCode (422, ModelState);
                }
                var currentCustomer = _customerQuery.GetById (id);
                if (currentCustomer == null) {
                    return NotFound ();
                }
                updateCustomer.id = id;
                var customer = _customerFactory.UpdatedCustomer(updateCustomer);
                var result = _customerCommands.Update(customer, updateCustomer);
                if(result == true) {
                return StatusCode (204);    
                } else {
                    return  StatusCode (500, $"internal server error");
                }

            } catch (Exception x) {
                return StatusCode (500, $"internal server error: {x.Message}");

            }
        }
// HTTP DELETE
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── V ──────────
//   :::::: S E N D I N G   H T T P   D E L E T E   R E Q U E S T   T O   D E L E T E   A   S E L E C T E D   C U S T O M E R : :  :   :    :     :        :          :
// ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
// DELETES A SELECTED CUSTOMER BY ITS ID

        [HttpDelete ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult DeleteCustomer (uint id) {
            try {
                var cstmr = _customerQuery.GetById (id);
                if (cstmr == null) {
                    return NotFound ($"customer with id: {id}, not found.");
                }
                _customerCommands.Delete (cstmr);
                return NoContent ();

            } catch (Exception x) {
                return StatusCode (500, $"Internal server error: {x.Message}");
            }

        }

    }

}