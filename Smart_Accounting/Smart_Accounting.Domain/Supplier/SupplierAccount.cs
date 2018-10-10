﻿/*
 * @CreateTime: Oct 9, 2018 9:57 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 9:38 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace Smart_Accounting.Domain.Supplier {
    public class SupplierAccount {
        public uint Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public uint SupplierId { get; set; }

        public Suppliers Supplier { get; set; }
    }
}