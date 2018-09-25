/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 25, 2018 11:44 AM
 * @Description: Modify Here, Please 
 */
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.Interfaces;

namespace Smart_Accounting.API.Controllers.Accountss
{
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountChartCommands _accountCommand;
        private readonly IAccountChartQueries _accountQuery;
        public AccountsController(IAccountChartCommands accountCmd,IAccountChartQueries accountQry) {
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
        public IActionResult CreatAccountType([FromBody] NewAccountModel newType) {
            _accountCommand.creatAccountType(newType);
            return StatusCode(201, newType);
        }
               
    }
}