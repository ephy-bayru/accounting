using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;

namespace Smart_Accounting.API.Controllers.AccountCharts
{
    [Route("api/AccountCharts")]
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllAccounts() {
            var accounts = _accountQuery.GetAll();
            return Ok(accounts);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreatAccountType([FromBody] NewAccountTypeModel newType) {
            _accountCommand.creatAccountType(newType);
            return StatusCode(201, newType);
        }
        


        
    }
}