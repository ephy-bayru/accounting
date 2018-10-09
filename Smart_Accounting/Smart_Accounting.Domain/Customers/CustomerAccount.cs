/*
 * @CreateTime: Oct 9, 2018 9:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 9:45 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain.Customers {
    public partial class CustomerAccount {
        public uint Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public uint CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}