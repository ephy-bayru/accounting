using System;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Commands {
    public class LedgersCommand : ILedgersCommand {
        private readonly IAccountingDatabaseService _database;
        private readonly ILogger<LedgersCommand> _logger;

        public LedgersCommand (IAccountingDatabaseService database,
            ILogger<LedgersCommand> logger) {
            _database = database;
            _logger = logger;
        }
        public Ledger CreateLedger (Ledger newLedger) {
            try {
                _database.Ledger.Add (newLedger);
                _database.Save ();
                return newLedger;
            } catch (Exception e) {
                _logger.LogError (500, e.Message);
                return null;
            }
        }

        public bool deleteLedger (Ledger deleteLedger) {
            try {
                _database.Ledger.Remove (deleteLedger);
                _database.Save ();
                return true;
            } catch (Exception e) {
                _logger.LogError (500, e.Message);
                return false;
            }
        }

        public bool UpdateLedger (Ledger updatedLedger) {
            try {
                _database.Ledger.Update (updatedLedger);
                _database.Save ();
                return true;

            } catch (Exception e) {
                _logger.LogError (500, e.Message);
                return false;
            }
        }
    }
}