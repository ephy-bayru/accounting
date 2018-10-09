/*
 * @CreateTime: Oct 9, 2018 9:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 11:15 AM
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
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerFactory _customerFactory;
        private ICustomerCommands _customerCommands;
        private ICustomerQuery _customerQuery;
        private readonly IResponseFactory _response;
        public CustomersController (
            ICustomerQuery customerQuery,
            ICustomerCommands customerCommand,
            ILogger<CustomersController> logger,
            ICustomerFactory customerFactory,
            IResponseFactory response
        ) {
            _customerQuery = customerQuery;
            _customerCommands = customerCommand;
            _logger = logger;
            _customerFactory = customerFactory;
            _response = response;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        public IActionResult GetAllCustomers () {
            var customers = _customerQuery.GetAll ();
            var customerView = _customerFactory.createCustomerView (customers);
            var response = _response.CreateCustomerResonse (customerView);
            return StatusCode (200, response);

        }

        [HttpGet ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult GetCustomerById (uint id) {
            try {
                var customers = _customerQuery.GetById (id);

                if (customers == null) {
                    return NotFound ($"customer with id: {id}, hasn't been found.");
                } else {
                    _logger.LogInformation ($"Returned customer with id: {id}");
                    return Ok (customers);
                }
            } catch (Exception x) {
                return StatusCode (500, $"something went wrong: {x.Message}");
            }
        }

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
                var result = _customerCommands.Create (customer);

                if (customer == null) {
                    return StatusCode (500, $"internal server error");
                } else {
                    return StatusCode (201, customer);
                }

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult UpdateCustomer (uint id, [FromBody] UpdateCustomerModel updateCustomer) {
            try {
                if (updateCustomer == null) {
                    return BadRequest ();
                }

                if (!ModelState.IsValid) {
                    return StatusCode (422);
                }
                var currentCustomer = _customerQuery.GetById (id);
                if (currentCustomer == null) {
                    return NotFound ();
                }
                _customerCommands.Update (currentCustomer, updateCustomer);
                return StatusCode (204);

            } catch (Exception x) {
                return StatusCode (500, $"internal server error: {x.Message}");

            }
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (typeof (string), 200)]
        public IActionResult DeleteCustomer (uint id) {
            try {
                var cstmr = _customerQuery.GetById (id);
                if (cstmr == null) {
                    _logger.LogError ($"customer with id: {id}, not found.");
                    return NotFound ();
                }
                _customerCommands.Delete (cstmr);
                return NoContent ();

            } catch (Exception x) {
                return StatusCode (500, $"Internal server error: {x.Message}");
            }

        }

    }

}