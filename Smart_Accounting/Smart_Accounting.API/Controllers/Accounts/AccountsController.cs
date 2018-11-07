/*
 * @CreateTime: Sep 24, 2018 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 4:06 PM
 * @Description: Account    
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

        /// <summary>
        /// returns account based on the id thats passed on its parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (AccountChart))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetAccountById (string id) {
            var account = _accountQuery.GetAccountById (id);

            if (account == null) { // if returned result  is  null return Not Found
                return StatusCode (404);
            }

            return StatusCode (200, account); // else return the account
        }

        /// <summary>
        /// Used to create single account from the parameter passed
        /// </summary>
        /// <param name="newAcounts"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType (201, Type = typeof (AccountChart))]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult CreateAccount ([FromBody] NewAccountModel newAcounts) { // used to create a single account 

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
            if (result == null) {
                return StatusCode (500, "Unknown Error Occured, Try Again!!!");
            }

            // return the newly created account
            return StatusCode (201, result);

        }
        /// <summary>
        /// Updates single account instance base on the id and account data
        /// passed on its argument
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedAccount"></param>
        /// <returns></returns>
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult UpdateAccount (string id, [FromBody] UpdatedAccountModel updatedAccount) {

            if (updatedAccount == null) { // if the data passed is in a wrong format return Bad Request
                return StatusCode (400, ModelState);
            }

            if (!ModelState.IsValid) { // if passed data doesnt satisfy the required model return unprocessable entity
                return StatusCode (422);
            }

            var account = _accountQuery.GetAccountById (id); // check if account exist
            if (account == null) {
                return StatusCode (404); // if account not found return 404
            }

            var update = _factory.UpdatedAccount (updatedAccount); // convert dto to domain object

            var add = _accountCommand.updateAccount (update); // add account
            if (add == false) { // if command fails return 500 server error
                return StatusCode (500);
            }

            return StatusCode (204); // if every thing checks out return successful 204 no content

        }

        /// <summary>
        /// Deletes account data based on the account id passed to its argument
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteAccount (string id) {
            var account = _accountQuery.GetAccountById (id);

            if (account == null) { // Check if account exists with provided ID
                return StatusCode (404);
            }
            var result = _accountCommand.deleteAccount (account); // delete the account found with the id
            if (result == false) {
                return StatusCode (500); // if deletion fails return 500 server error
            }

            return StatusCode (204); //

        }

    }
}