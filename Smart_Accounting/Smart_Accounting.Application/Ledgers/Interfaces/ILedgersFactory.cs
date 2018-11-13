/*
 * @CreateTime: Oct 17, 2018 2:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:45 PM
 * @Description: Modify Here, Please 
 */

using Smart_Accounting.Application.Ledgers.Models;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Interfaces {
    public interface ILedgersFactory {
        Ledger CreateGeneralLedgerEntry (NewLedgerEntryDto newLedger);



    }
}
