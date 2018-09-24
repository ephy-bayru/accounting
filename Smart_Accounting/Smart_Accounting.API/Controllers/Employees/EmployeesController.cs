using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.API.Controllers.Employee {
    [Route ("api/employees")]
    public class EmployeesController : Controller {
        private IEmployeesQueries _employeesQuery;
        private IEmployeeCommands _employeeCommands;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IResponseFactory _response;

        public EmployeesController (IEmployeesQueries employeeQuery,
            IEmployeeCommands employeeCommand,
            ILogger<EmployeesController> logger,
            IEmployeeFactory employeeFactory,
            IResponseFactory response) {
            _employeesQuery = employeeQuery;
            _employeeCommands = employeeCommand;
            _logger = logger;
            _employeeFactory = employeeFactory;
            _response = response;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        public IActionResult GetAllEmployees () {



                var employees = _employeesQuery.GetAll ();
                _logger.LogInformation ($"Returned all employees from database.");
                var view = _employeeFactory.createEmployeeView(employees);

                var response = _response.CreateEmployeeResponse(view);
                return StatusCode (200,response);

        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        public IActionResult GetEmployeeById (uint id) {

            try {
                var employees = _employeesQuery.GetById (id);

                if (employees == null) {
                    _logger.LogError ($"employee with id: {id}, hasn't been found.");
                    return NotFound ();
                } else {
                    _logger.LogInformation ($"Returned employee with id: {id}");
                    return Ok (employees);
                }
            } catch (Exception x) {
                _logger.LogError ($"sonething went wrong: {x.Message}");
                return StatusCode (500, "internal serve error");
            }
        }

        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        public IActionResult CreateNewEmployee ([FromBody] NewEmployeeModel newEmployee) {

            try {
                if (newEmployee == null) {
                    _logger.LogError ("Empty users data");
                    return BadRequest ("user data is empty");
                }
                if (!ModelState.IsValid) {
                    _logger.LogError ("invalid data sent from users");
                    return StatusCode(422, "Invalid user model");
                }

                _employeeCommands.Create (newEmployee);
                return StatusCode (201, newEmployee);

            } catch (Exception x) {
                _logger.LogError ($"something went wrong: {x.Message}");
                return StatusCode (500, "internal server error");
            }

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        public IActionResult UpdateEmployee (uint id, [FromBody] UpdatedEmployeeDto updateEmployee) {
            try {
                if (updateEmployee == null) {
                    return BadRequest ();
                }

                if (!ModelState.IsValid) {
                    return StatusCode (422);
                }
               var currentEmployee =   _employeesQuery.GetById (id);
               if( currentEmployee == null ) {
                   return NotFound();
               }
                _employeeCommands.Update (currentEmployee, updateEmployee );
                return StatusCode (204);

            } catch (Exception x) {
                _logger.LogError ($"something went wrong: {x.Message}");
                return StatusCode (500, "internal server error");

            }
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        public IActionResult DeleteEmployee (uint id) {
            try {
                var emp = _employeesQuery.GetById (id);
                if (emp == null) {
                    _logger.LogError ($"employee with id: {id}, not found.");
                    return NotFound ();
                }
                _employeeCommands.Delete (emp);
                return NoContent ();

            } catch (Exception x) {
                _logger.LogError ($"Something went wrong: {x.Message}");
                return StatusCode (500, "Internal server error");
            }

        }

    }
}