/*
 * @CreateTime: Oct 17, 2018 2:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:15 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class NewLedgerEntryDto : LedgerDto {

        public List<NewJornalEntryDto> Jornal {get; set;} = new List<NewJornalEntryDto>();
    }
}

