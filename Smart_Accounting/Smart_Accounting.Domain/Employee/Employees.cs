/*
 * @CreateTime: Nov 2, 2018 3:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:01 PM
 * @Description: Modify Here, Please 
 */
using System;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Employe {
    public partial class Employees {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}