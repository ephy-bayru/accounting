/*
 * @CreateTime: Nov 2, 2018 2:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 13, 2018 11:52 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.Currencies;
using Smart_Accounting.Domain.Ledgers;
using Smart_Accounting.Domain.PostingTypes;

namespace Smart_Accounting.Domain.Jornals {
    public class Jornal {
        public uint JornalId { get; set; }
        public double Amount { get; set; }
        public uint LedgerId { get; set; }
        public string AccountId { get; set; }
        public sbyte? Reconciled { get; set; }
        public string Status { get; set; }
        public uint? PostingType { get; set; }
        public uint? PostingEntityId { get; set; }
        public DateTime? ReconcieldOn { get; set; }
        public uint CurrencyCode { get; set; }
        public string Reference { get; set; }
        public float ExchangeRate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public AccountChart Account { get; set; }
        public Ledger Ledger { get; set; }
        public PostingType PostingTypeNavigation { get; set; }

    }
}