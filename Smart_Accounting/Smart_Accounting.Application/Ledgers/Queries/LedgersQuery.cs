/*
 * @CreateTime: Oct 18, 2018 10:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 27, 2018 11:20 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Application.Ledgers.Models;
using Smart_Accounting.Domain.Jornals;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Queries {
    public class LedgersQuery : ILedgersQuery {
        private readonly IAccountingDatabaseService _database;
        private readonly ILogger<LedgersQuery> _logger;

        public LedgersQuery (IAccountingDatabaseService database,
            ILogger<LedgersQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IEnumerable<Ledger> GetAllLedgerEntry () {
            return _database.Ledger.Select (ledger => new Ledger () {
                Id = ledger.Id,
                    PeriodId = ledger.PeriodId,
                    DateAdded = ledger.DateAdded,
                    DateUpdated = ledger.DateUpdated,
                    Discription = ledger.Discription,
                    Jornal = ledger.Jornal
            }).ToList ();
        }

        public IEnumerable<LedgerEntryViewModel> GetAllLedgerEntryView()
        {
            return _database.Ledger.Select(l => new LedgerEntryViewModel() {
                    Id = l.Id,
                    Description = l.Discription,
                    CreatedOn = (DateTime) l.DateAdded,
                    Period = $"{l.Period.Start} {l.Period.End}",
                    Jornals = l.Jornal.Select(j => new JornalEntryViewModel(){
                        Id = j.JornalId,
                        Amount = (float) j.Amount,
                        AccountId = j.AccountId,
                        Account = j.Account.AccountId
                    }).ToList()
            }).ToList();
        }

        public Ledger GetLedgerEntryById (uint id) {
            return _database.Ledger.Select (ledger => new Ledger () {
                Id = ledger.Id,
                    PeriodId = ledger.PeriodId,
                    Discription = ledger.Discription,
                    Jornal = ledger.Jornal.Select (jor => new Jornal () {
                        JornalId = jor.JornalId,
                            Amount = jor.Amount,
                            Reference = jor.Reference,
                            AccountId = jor.AccountId
                    }).ToList ()
            }).FirstOrDefault(ledger => ledger.Id == id);
        }
    }
}