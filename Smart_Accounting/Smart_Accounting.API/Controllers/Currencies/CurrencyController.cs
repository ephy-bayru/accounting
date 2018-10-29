using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Smart_Accounting.Domain.Currencies;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Application.Currencies.Interfaces;
using Smart_Accounting.Application.Currencies.Commands.Factories;

namespace Smart_Accounting.API.Controllers.Currencies
{
    [Route("api/currency")]
    public class CurrencyController : Controller
    {
        private ICurrencyQueries _currencyQuery;
        private ICurrencyCommands _currencyCommands;
        private readonly ICurrencyFactory _currencyFactory;
        private readonly IResponseFactory _response;

        public CurrencyController(
            ICurrencyQueries currencyQuery,
            ICurrencyCommands currencyCommand,
            ICurrencyFactory currencyFactory,
            IResponseFactory response)
        {
            _currencyQuery = currencyQuery;
            _currencyCommands = currencyCommand;
            _currencyFactory = currencyFactory;
            _response = response;
        }
        // FETCH CURRENCIES
        // ─── METHOD TO GET ALL CURRENCIES FROM DATABASE ─────────────────────────────────
        //HTTP GET
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetAllCurrency()
        {
            // try
            // {
            var currencies = _currencyQuery.GetAll();
            var view = _currencyFactory.createCurrencyView(currencies);
            var response = _response.CreateCurrencyResponse(view);
            return StatusCode(200, response);
            // }
            // catch (Exception c)
            // {
            //     return StatusCode(500, $"internal server error: {c.Message}");
            // }

        }
        // FETCH A SINGLE CURRENCY
        // ─── METHOD TO GET A SINGLE CURRENCY FROM DATABASE ──────────────────────────────
        // HTTP GET
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCurrencyById(uint id)
        {
            try
            {
                var currency = _currencyQuery.GetById(id);

                if (currency == null)
                {
                    return NotFound($"currency with id: {id}, hasn't been found.");
                }
                else
                {
                    return Ok(currency);
                }
            }
            catch (Exception c)
            {
                return StatusCode(500, $"internal server error: {c.Message}");
            }
        }
        // ADD A SINGLE CURRENCY TO DATEBASE
        // ─── METHOD TO ADD A CURRENCY TO DATABASE ───────────────────────────────────────
        // HTTP POST
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewCurrency([FromBody] Currency currency)
        {
            // try
            // {
                if (currency == null)
                {
                    return BadRequest("Empty currency data!");
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(422, "Invalid data sent!");
                }
                _currencyCommands.Create(currency);
                return StatusCode(201, currency);
            // }
            // catch (Exception c)
            // {

            //     return StatusCode(500, $"internal server error: {c.Message}");
            // }

        }
        // UPDATE A SINGLE CURRENCY IN THE DATABASE
        // ─── METHOD TO UPDATE AN EXISTING CURRENCY IN THE DATABASE ──────────────────────
        // HTTP PUT
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateCurrency(uint id, [FromBody] UpdateCurrencyModel updateCurrency)
        {
            try
            {
                if (updateCurrency == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(422, "Empty currency data!");
                }
                var currentCurrency = _currencyQuery.GetById(id);
                if (currentCurrency == null)
                {
                    return NotFound($"There is no Currency with id: {id}");
                }
                _currencyCommands.Update(currentCurrency, updateCurrency);
                return StatusCode(204, "updated!");

            }
            catch (Exception c)
            {
                return StatusCode(500, $"internal server error: {c.Message}");

            }
        }
        // DELETE A CURRENCY FROM DATABASE
        // ─── METHOD TO DELETE A CURRENCY IN THE DATABASE ────────────────────────────────
        // HTTP DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult DeleteCurrency(uint id)
        {
            try
            {
                var emp = _currencyQuery.GetById(id);
                if (emp == null)
                {
                    return NotFound($"there is no currency with id: {id}");
                }
                _currencyCommands.Delete(emp);
                return NoContent();

            }
            catch (Exception c)
            {
                return StatusCode(500, $"Internal server error: {c.Message}");
            }

        }
    }
}