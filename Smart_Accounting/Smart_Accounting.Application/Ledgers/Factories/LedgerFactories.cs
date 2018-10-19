/*
 * @CreateTime: Oct 17, 2018 2:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:37 PM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Application.Ledgers.Models;
using Smart_Accounting.Domain.Jornals;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Factories {
    public class LedgerFactories : ILedgersFactory {
        public Ledger CreateLedger (NewLedgerEntryDto newLedger) {
            Ledger ledger = new Ledger () {
                PeriodId = newLedger.PeriodId,
                Discription = newLedger.Description,

            };

            foreach (var item in newLedger.Jornal) {
                ledger.Jornal.Add (new Jornal () {
                    Credit = item.Credit,
                        AccountId = item.AccountId,
                        Debit = item.Debit,
                        Reference = item.Reference
                });
            }

            return ledger;
        }
    }
}