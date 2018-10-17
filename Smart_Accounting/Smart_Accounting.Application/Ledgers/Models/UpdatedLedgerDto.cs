/*
 * @CreateTime: Oct 17, 2018 2:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:18 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class UpdatedLedgerDto : LedgerDto {
        public uint Id { get; set; }
        public List<UpdatedJornalEntryDto> Jornal { get; set; } = new List<UpdatedJornalEntryDto> ();

    }
}