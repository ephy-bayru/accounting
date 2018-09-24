/*
 * @CreateTime: Sep 24, 2018 9:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 24, 2018 9:22 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.Organizations.Models {
    public class OrganizationModelDto {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        public string Tin { get; set; }
    }
}