/*
 * @CreateTime: Oct 17, 2018 2:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 13, 2018 12:37 PM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Application.Ledgers.Models;
using Smart_Accounting.Domain.Jornals;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Factories {
    public class LedgerFactories : ILedgersFactory {
        private readonly ICalendarPeriodQueries _calanderQuery;

        public LedgerFactories(ICalendarPeriodQueries calanderQuery) {
            _calanderQuery = calanderQuery;
        }

        public Ledger CreateGeneralLedgerEntry(NewLedgerEntryDto newLedger)
        {
                Ledger ledger = new Ledger () {
                PeriodId = _calanderQuery.getActivePeriodId(),
                Discription = newLedger.Description,

            };

            foreach (var item in newLedger.Jornal) {
                ledger.Jornal.Add (new Jornal () {
                        Amount = item.Amount,
                        AccountId = item.AccountId,
                        Reference = item.Reference.ToString(),
                        PostingType = item.PostingType,
                        PostingEntityId = item.PostingEntityId                        
                });
            }

            return ledger;
        }

        public Ledger CreatePaymentLedgerEntry(NewLedgerEntryDto newLedger)
        {
            throw new System.NotImplementedException();
        }
    }

}