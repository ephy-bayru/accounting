/*
 * @CreateTime: Aug 31, 2018 1:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 31, 2018 1:03 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Organizations.Models {
    public class UpdatedOrganizationModel : OrganizationModelDto {
        [Required]
        public uint id { get; set; }
    }

}