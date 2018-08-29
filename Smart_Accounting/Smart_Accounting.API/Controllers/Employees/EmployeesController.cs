using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;

namespace Smart_Accounting.API.Controllers.Employee
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private IEmployeesQueries _employeesQuery;
        private IEmployeeCommands _employeeCommands;
        public EmployeesController(IEmployeesQueries employeeQuery,
                                    IEmployeeCommands employeeCommand) {
            _employeesQuery = employeeQuery;
            _employeeCommands = employeeCommand;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllEmployees() {
            var employees = _employeesQuery.GetAll();
            
            return Ok(employees);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetEmployeeById(uint id) {
            var employees = _employeesQuery.GetById(id);
            
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewEmployee(NewEmployeeModel newEmployee) {
            _employeeCommands.Create(newEmployee);
            return StatusCode(201, newEmployee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateEmployee(uint id, NewEmployeeModel newEmployee) {
            _employeeCommands.Create(newEmployee);
            return Ok(newEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult DeleteEmployee(uint id) {

            var exists = _employeesQuery.GetById(id);

            if (exists == null) {
                return NotFound();
            }
            _employeeCommands.Delete(exists);

            return NoContent();
            
        }
        
    }
}