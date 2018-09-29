/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 25, 2018 12:12 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.API.Controllers.Accountss {
    [Route ("api/accounts")]
    public class AccountsController : Controller {
        private readonly IAccountChartCommands _accountCommand;
        private readonly IAccountChartQueries _accountQuery;
        private readonly IAccountChartFactory _factory;

        public AccountsController (
            IAccountChartCommands accountCmd,
            IAccountChartQueries accountQry,
            IAccountChartFactory accountFactory) {
            _accountCommand = accountCmd;
            _accountQuery = accountQry;
            _factory = accountFactory;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (AccountChart))]
        [ProducesResponseType (500)]
        public IActionResult GetAllAccounts () {
            var account = _accountQuery.GetAll ();

            return StatusCode (200, account);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (AccountChart))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetAccountById (uint id) {
            var account = _accountQuery.GetById (id);

            if (account == null) {
                return StatusCode (404);
            }

            return StatusCode (200, account);
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (AccountChart))]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult CreateAccount ([FromBody] IEnumerable<NewAccountModel> newAcounts) {

            if (newAcounts == null) {
                return StatusCode (400); // Bad Request
            }

            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var accounts = _factory.NewAccount (newAcounts);

            var result = _accountCommand.createAccount (accounts);

            return StatusCode (201, result);
        }

    }
}