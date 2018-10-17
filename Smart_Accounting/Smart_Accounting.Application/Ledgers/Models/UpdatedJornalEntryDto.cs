/*
 * @CreateTime: Oct 17, 2018 2:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:17 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Ledgers.Models {
    public class UpdatedJornalEntryDto : JornalEntryDto {

        [Key]
        [Required]
        public uint JornalId { get; set; }
    }
}