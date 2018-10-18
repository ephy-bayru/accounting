/*
 * @CreateTime: Oct 18, 2018 10:10 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 10:10 AM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Application.Ledgers.Interfaces {
    public interface ILedgersCommand {
        Ledger CreateLedger (Ledger newLedger);
        bool UpdateLedger (Ledger updatedLedger);
        bool deleteLedger (Ledger deleteLedger);
    }
}