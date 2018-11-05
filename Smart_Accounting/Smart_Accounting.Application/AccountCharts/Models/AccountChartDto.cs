/*
 * @CreateTime: Sep 25, 2018 12:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:30 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.AccountCharts.Models {
    public abstract class AccountChartDto {
        
        public string AccountCode { get; set; } // holds Parent Account ID if available
        [Required]
        public string Name { get; set; }
        [Required]
        public string AccountId { get; set; }
        public sbyte? Active { get; set; } // holds the value of accounts current status
        [Required]
        public string AccountType { get; set; } // Holds Value of 'Asset', 'Liability', 'Expence', 'Equity'
        [Required]
        public uint OrganizationId { get; set; } 

        [Required]
        public string GlType {get; set;} // Has value of 'Income Balance or Balance Sheet'
        [Required]
        public string PostingType {get; set;} // Has value of 'Credit' 'Debit' or 'Both'

        [Required]
        public sbyte? isReconciliation {get; set;} // used to determin is account reconciliation is required for the account
        [Required]
        public sbyte? isPosting {get; set;} // used to determine if direct posting by the user is allowed for this account

    }
}