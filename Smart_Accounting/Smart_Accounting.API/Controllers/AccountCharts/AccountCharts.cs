using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;

namespace Smart_Accounting.API.Controllers.AccountCharts
{
    [Route("api/AccountChart")]
    public class AccountCharts : Controller
    {
        private readonly IAccountChartCommands _accountCommand;
        private readonly IAccountChartQueries _accountQuery;
        public AccountCharts(
                                IAccountChartCommands accountCmd, 
                                IAccountChartQueries accountQry) {
            _accountCommand = accountCmd;
            _accountQuery = accountQry;
        }

        [HttpGet("types")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllAccountTypes() {
            var accounts = _accountQuery.GetAllAccountTypes();
            return Ok(accounts);
        }

        [HttpPost("types")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreatAccountType([FromBody] NewAccountTypeModel newType) {
            _accountCommand.creatAccountType(newType);
            return StatusCode(201, newType);
        }
        


        
    }
}