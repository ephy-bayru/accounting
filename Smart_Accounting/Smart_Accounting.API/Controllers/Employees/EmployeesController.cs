using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Models;

namespace Smart_Accounting.API.Controllers.Employee
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private ILoggerManager _logger;
        private IEmployeesQueries _employeesQuery;
        private IEmployeeCommands _employeeCommands;
        public EmployeesController(IEmployeesQueries employeeQuery,
                                    IEmployeeCommands employeeCommand,
                                    ILoggerManager logger) {
            _employeesQuery = employeeQuery;
            _employeeCommands = employeeCommand;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllEmployees() {
            
            return Ok(employees);
            try
            {
            var employees = _employeesQuery.GetAll();
            _logger.LogInfo($"Returned all employees from database.");
            return Ok(employees);                
            }
            catch (Exception x)
            {
                _logger.LogError($"something went wrong: {x.Message}");
                return StatusCode(500, "Internal server error");
                throw;
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetEmployeeById(uint id) {
            
            return Ok(employees);
            try
            {
            var employees = _employeesQuery.GetById(id);
            if(employees == null)
            {
                _logger.LogError("employee with id: {id}, hasn't been found.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Returned employee with id: {id}");
                return Ok(employees);
            }
            }
            catch (Exception x)
            {
             _logger.LogError($"sonething went wrong: {x.Message}");
             return StatusCode(500, "internal serve error");   
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewEmployee([FromBody] NewEmployeeModel newEmployee) {
           
           try
           {
               if(newEmployee == null)
               {
                   _logger.LogError("Empty users data");
                   return BadRequest("user data is empty");
               }
               else if(!ModelState.IsVAlid)
               {
                   _logger.LogError("invalid data sent from users");
                   return BadRequest("Invalid user model");
               }
               else if(newEmployee != null && ModelState.IsVAlid) 
               {
                _employeeCommands.Create(newEmployee);
                return StatusCode(201, newEmployee);
               }
           }
           catch (Exception x)
           {
               _logger.LogError($"something went wrong: {x.Message}");
               return StatusCode(500, "internal server error");
               throw;
           } 
           
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateEmployee(uint id,[FromBody] NewEmployeeModel updateEmployee) {
           try
           {
               if(updateEmployee == null)
               {

               }
               else if(!ModelState.IsVAlid)
               {
                  
               }
               else if(ModelState.IsVAlid && updateEmployee)
               {
                    _query.GetEmployeeById (id);
                    _command.UpdateEmployee(updateEmployee != null);
               }
           }
           catch (Exception x)
           {
               return StatusCode(500. "internal server error");
               throw;
           }
           
            _employeeCommands.Create(updateEmployee);
            return Ok(updateEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult DeleteEmployee(uint id) {
            try
            {
                var emp = _employeesQuery.GetById(id);
                if(emp == null)
                {
                    _logger.LogError($"employee with id: {id}, not found.");
                    return NotFound();
                }
                _employeesQuery.DeleteEmployee(emp);
                _employeeCommands.Delete(emp);
                  return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError($"Something went wrong: {x.Message}");
                return StatusCode(500, "Internal server error");
                throw;
            }
           
        }
        
    }
}