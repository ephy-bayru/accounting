/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 4:06 PM
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
        public IActionResult GetAllAccounts (string type = "ALL") {

            var account = _accountQuery.GetAllAccounts (type);

            return StatusCode (200, account);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (AccountChart))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetAccountById (string id) {
            var account = _accountQuery.GetAccountById (id);

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
        public IActionResult CreateAccount ([FromBody] NewAccountModel newAcounts) {  // used to create a single account 
            
            // if data passed from user has a bad format return 400(Bad Request)
            if (newAcounts == null) {
                return StatusCode (400);
            }

            // if data passed is not valid return 422(Unprocessable entity) with the modelstate value in the body
            if (!ModelState.IsValid) {
                return StatusCode (422, ModelState);
            }
            //convert account DTO to domain object
            var accounts = _factory.NewAccount (newAcounts);

            // save the new account domain object in the database
            var result = _accountCommand.createAccount (accounts);
            
            // check if database  entry was successful
            if(result == null) {
                return StatusCode(500, "Unknown Error Occured, Try Again!!!");
            }

            // return the newly created account
            return StatusCode (201, result);

        }

        [HttpPut("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult UpdateAccount (string id, [FromBody] UpdatedAccountModel updatedAccount) {
            List<AccountChart> accounts = new List<AccountChart> ();

            if(updatedAccount == null) {
                return StatusCode(400, ModelState);
            }

            if(!ModelState.IsValid) {
                return StatusCode(422);
            }


            var account  = _accountQuery.GetAccountById(id);
                if(account == null) {
                    return StatusCode(404);
                }

                var update = _factory.UpdatedAccount(updatedAccount);
            

            var add = _accountCommand.updateAccount (update);
            if (add == false) {
                return StatusCode (500);
            }

            return StatusCode (204);

        }

        [HttpDelete]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteAccount (string id) {
            var account = _accountQuery.GetAccountById (id);

            if (account == null) {
                return StatusCode (404);
            }
            var result = _accountCommand.deleteAccount (account);
            if (result == false) {
                return StatusCode (500);
            }

            return StatusCode (204);

        }

    }
}