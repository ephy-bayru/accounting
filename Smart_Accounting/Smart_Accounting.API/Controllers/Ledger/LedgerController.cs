/*
 * @CreateTime: Oct 18, 2018 10:24 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 10:24 AM
 * @Description: Modify Here, Please 
 */
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Application.Ledgers.Models;

namespace Smart_Accounting.API.Controllers.Ledger {
    [Route ("api/ledger")]
    public class LedgerController : Controller {
        private readonly ILedgersCommand _commands;
        private readonly ILedgersQuery _query;
        private readonly ILedgersFactory _factory;
        private readonly ICalendarPeriodQueries _calendarQuery;

        public LedgerController (ILedgersCommand commands, ILedgersQuery query, ILedgersFactory factory) {
            _commands = commands;
            _query = query;
            _factory = factory;
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (LedgerEntryViewModel))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetLedgerEntryById (uint id) {

            var ledger = _query.GetLedgerEntryById (id);

            if (ledger == null) {
                return StatusCode (404);
            }

            return StatusCode (200, ledger);
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (LedgerEntryViewModel))]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetAllLedgerEntryBy () {

            var ledger = _query.GetAllLedgerEntry();

            if (ledger == null) {
                return StatusCode (404);
            }

            return StatusCode (200, ledger);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LedgerEntryViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult AddLedgerEntry([FromBody] NewLedgerEntryDto newEntry) {

                    if(newEntry == null){
                        return StatusCode(400);
                    }
                    if(!ModelState.IsValid) {
                        return StatusCode(422, ModelState);
                    }
                    var entry = _factory.CreateLedger(newEntry);

                    var result = _commands.CreateLedger(entry);

                    if (result == null) {
                        return StatusCode(500);
                    }

                    return StatusCode(201, result);
        }

    }
}