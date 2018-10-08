/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 24, 2018 11:43 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.API.Controllers.Employee
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private IEmployeesQueries _employeesQuery;
        private IEmployeeCommands _employeeCommands;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IResponseFactory _response;

        public EmployeesController(IEmployeesQueries employeeQuery,
            IEmployeeCommands employeeCommand,
            ILogger<EmployeesController> logger,
            IEmployeeFactory employeeFactory,
            IResponseFactory response)
        {
            _employeesQuery = employeeQuery;
            _employeeCommands = employeeCommand;
            _employeeFactory = employeeFactory;
            _response = response;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllEmployees()
        {

            var employees = _employeesQuery.GetAll();
            var view = _employeeFactory.createEmployeeView(employees);
            var response = _response.CreateEmployeeResponse(view);
            return StatusCode(200, response);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetEmployeeById(uint id)
        {

            try
            {
                var employees = _employeesQuery.GetById(id);

                if (employees == null)
                {
                    return NotFound($"employee with id: {id}, hasn't been found.");
                }
                else
                {
                    return Ok(employees);
                }
            }
            catch (Exception x)
            {
                return StatusCode(500, $"internal serve error: {x.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewEmployee([FromBody] NewEmployeeModel newEmployee)
        {

            
                if (newEmployee == null)
                {
                    return BadRequest("Empty user data!");
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(422, "Invalid data sent from users");
                }
                _employeeCommands.Create(newEmployee);
                return StatusCode(201, newEmployee);
            }
           

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateEmployee(uint id, [FromBody] UpdatedEmployeeDto updateEmployee)
        {
            try
            {
                if (updateEmployee == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(422);
                }
                var currentEmployee = _employeesQuery.GetById(id);
                if (currentEmployee == null)
                {
                    return NotFound();
                }
                _employeeCommands.Update(currentEmployee, updateEmployee);
                return StatusCode(204);

            }
            catch (Exception x)
            {
                return StatusCode(500, $"internal server error: {x.Message}");

            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult DeleteEmployee(uint id)
        {
            try
            {
                var emp = _employeesQuery.GetById(id);
                if (emp == null)
                {
                    return NotFound();
                }
                _employeeCommands.Delete(emp);
                return NoContent();

            }
            catch (Exception x)
            {
                return StatusCode(500, $"Internal server error: {x.Message}");
            }

        }

    }
}