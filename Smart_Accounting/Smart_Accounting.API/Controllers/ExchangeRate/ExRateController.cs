using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Smart_Accounting.Domain.ExchangeRates;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Application.ExchnageRate.Interfaces;
using Smart_Accounting.Application.ExchnageRate.Commands.Factories;

namespace Smart_Accounting.API.Controllers.ExchnageRate
{
    [Route("api/xrate")]
    public class ExRateController : Controller
    {
        private IExRateQueries _rateQuery;
        private IExRateCommands _rateCommands;
        private readonly IExRateFactory _rateFactory;
        private readonly IResponseFactory _response;

        public ExRateController(
            IExRateQueries rateQuery,
            IExRateCommands rateCommand,
            IExRateFactory rateFactory,
            IResponseFactory response)
        {
            _rateQuery = rateQuery;
            _rateCommands = rateCommand;
            _rateFactory = rateFactory;
            _response = response;
        }
        // FETCH EXCHANGE RATE
        // ─── METHOD TO GET ALL RATE FROM DATABASE ───────
        //HTTP GET
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetAllExRate()
        {
            try
            {
            var exrate = _rateQuery.GetAll();
            var view = _rateFactory.createExRateView(exrate);
            return StatusCode(200);
            }
            catch (Exception c)
            {
                return StatusCode(500, $"internal server error: {c.Message}");
            }

        }
        // FETCH A SINGLE EXCHANGE RATE VALUE
        // ─── METHOD TO GET A SINGLE EXCHANGE RATE FROM DATABASE ────
        // HTTP GET
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetExRateById(uint id)
        {
            try
            {
                var exRate = _rateQuery.GetById(id);

                if (exRate == null)
                {
                    return NotFound($"exchange rate with id: {id}, hasn't been found.");
                }
                else
                {
                    return Ok(exRate);
                }
            }
            catch (Exception c)
            {
                return StatusCode(500, $"internal server error: {c.Message}");
            }
        }
        // ADD A SINGLE EXCHANGE RATE TO DATEBASE
        // ─── METHOD TO ADD A EXCHANGE RATE TO DATABASE ──
        // HTTP POST
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateNewExRate([FromBody] ExchangeRate exchangeRate)
        {
            try
            {
                if (exchangeRate == null)
                {
                    return BadRequest("Empty exchange rate data!");
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(422, "Invalid data sent!");
                }
                _rateCommands.Create(exchangeRate);
                return StatusCode(201, exchangeRate);
            }
            catch (Exception c)
            {

                return StatusCode(500, $"internal server error: {c.Message}");
            }

        }
        // UPDATE A SINGLE EXCHANGE RATE IN THE DATABASE
        // ─── METHOD TO UPDATE AN EXISTING EXCHANGE RATE IN THE DATABASE ──────
        // HTTP PUT
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult UpdateExRate(uint id, [FromBody] UpdateExRateModel updateExRateModel)
        {
            try
            {
                if (updateExRateModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(422, "Empty exchange rate data!");
                }
                var exRate = _rateQuery.GetById(id);
                if (exRate == null)
                {
                    return NotFound($"There is no exchange rate with id: {id}");
                }
                _rateCommands.Update(exRate, updateExRateModel);
                return StatusCode(204, "updated!");

            }
            catch (Exception c)
            {
                return StatusCode(500, $"internal server error: {c.Message}");

            }
        }
        // DELETE A EXCHANGE RATE FROM DATABASE
        // ─── METHOD TO DELETE A EXCHANGE RATE IN THE DATABASE ─────
        // HTTP DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult DeleteExRate(uint id)
        {
            try
            {
                var rate = _rateQuery.GetById(id);
                if (rate == null)
                {
                    return NotFound($"there is no exchange rate with id: {id}");
                }
                _rateCommands.Delete(rate);
                return NoContent();

            }
            catch (Exception c)
            {
                return StatusCode(500, $"Internal server error: {c.Message}");
            }

        }
    }
}