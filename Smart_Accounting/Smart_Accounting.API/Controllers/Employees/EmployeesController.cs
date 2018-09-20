using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;

namespace Smart_Accounting.API.Controllers.Employee {
    [Route ("api/employees")]
    public class EmployeesController : Controller {
        private IEmployeesQueries _employeesQuery;
        private IEmployeeCommands _employeeCommands;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController (IEmployeesQueries employeeQuery,
            IEmployeeCommands employeeCommand,
            ILogger<EmployeesController> logger) {
            _employeesQuery = employeeQuery;
            _employeeCommands = employeeCommand;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        public IActionResult GetAllEmployees () {

            try {

                var employees = _employeesQuery.GetAll ();
                _logger.LogInformation ($"Returned all employees from database.");
                return Ok (employees);

            } catch (Exception x) {
                _logger.LogError ($"something went wrong: {x.Message}");
                return StatusCode (500, "Internal server error");
            }
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        public IActionResult GetEmployeeById (uint id) {

            try {
                var employees = _employeesQuery.GetById (id);

                if (employees == null) {
                    _logger.LogError ("employee with id: {id}, hasn't been found.");
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
                    return BadRequest ("Invalid user model");
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
        public IActionResult UpdateEmployee (uint id, [FromBody] NewEmployeeModel updateEmployee) {
            try {
                if (updateEmployee == null) {
                    return BadRequest ();
                }

                if (!ModelState.IsValid) {
                    return StatusCode (422);
                }
                _employeesQuery.GetEmployeeById (id);
                _employeeCommands.UpdateEmployee (updateEmployee);
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
                var emp = _employeesQuery.GetEmployeeById (id);
                if (emp == null) {
                    _logger.LogError ($"employee with id: {id}, not found.");
                    return NotFound ();
                }
                _employeesQuery.DeleteEmployee (emp);
                _employeeCommands.Delete (emp);
                return NoContent ();

            } catch (Exception x) {
                _logger.LogError ($"Something went wrong: {x.Message}");
                return StatusCode (500, "Internal server error");
            }

        }

    }
}