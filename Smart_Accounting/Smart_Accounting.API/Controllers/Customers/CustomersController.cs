using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Factories;
using Smart_Accounting.Application.Customers.Commands;
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Domain.Customers;
using Microsoft.Extensions.Logging;

namespace Smart_Accounting.API.Controllers.Customers
{

    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerFactory _customerFactory;
        private ICustomerCommands _customerCommands;
        private ICustomerQuery _customerQuery;
        private readonly IResponseFactory _response;
        public CustomersController(
          ICustomerQuery customerQuery,
          ICustomerCommands customerCommand,
          ILogger<CustomersController> logger,
          ICustomerFactory customerFactory,
          IResponseFactory response
        )
        {
            _customerQuery = customerQuery;
            _customerCommands = customerCommand;
            _logger = logger;
            _customerFactory = customerFactory;
            _response = response;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllCustomers()
        {
        var customers = _customerQuery.GetAll();
        var customerView = _customerFactory.createCustomerView(customers);
        var response = _response.CreateCustomerResonse(customerView);
        return StatusCode(200, response);

        }


        [HttpGet("{id}")]
        public IActionResult GetCustomerById(uint id)
        {
            try
            {
                var customers = _customerQuery.GetById(id);

                if (customers == null)
                {
                    _logger.LogError($"customer with id: {id}, hasn't been found.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned customer with id: {id}");
                    return Ok(customers);
                }
            }
            catch (Exception x)
            {
                _logger.LogError($"sonething went wrong: {x.Message}");
                return StatusCode(500, "internal serve error");
            }
        }


        [HttpPost]
        public IActionResult CreateNewCustomer([FromBody] NewCustomerModel newCustomer)
        {
            try
            {
                if (newCustomer == null)
                {
                    _logger.LogError("Empty customers data");
                    return BadRequest("data is empty");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("invalid data sent from users");
                    return StatusCode(422, "Invalid customer model");
                }

                _customerCommands.Create(newCustomer);
                _logger.LogInformation("successfully registered new customer!");
                return StatusCode(201, newCustomer);

            }
            catch (Exception x)
            {
                _logger.LogError($"something went wrong: {x.Message}");
                return StatusCode(500, "internal server error");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(uint id, [FromBody] UpdateCustomerModel updateCustomer)
        {
            try
            {
                if (updateCustomer == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(422);
                }
                var currentCustomer = _customerQuery.GetById(id);
                if (currentCustomer == null)
                {
                    return NotFound();
                }
                _customerCommands.update(currentCustomer, updateCustomer);
                return StatusCode(204);

            }
            catch (Exception x)
            {
                _logger.LogError($"something went wrong: {x.Message}");
                return StatusCode(500, "internal server error");

            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(uint id)
        {
            try
            {
                var cstmr = _customerQuery.GetById(id);
                if (cstmr == null)
                {
                    _logger.LogError($"customer with id: {id}, not found.");
                    return NotFound();
                }
                _customerCommands.delete(cstmr);
                return NoContent();

            }
            catch (Exception x)
            {
                _logger.LogError($"Something went wrong: {x.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

    }

}
