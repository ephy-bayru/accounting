/*
 * @CreateTime: Sep 25, 2018 12:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 11:54 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.AccountCharts;


namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartQueries {
        AccountChart GetAccountById (string accountId);
        IEnumerable<AccountChart> GetAllAccounts (string type);

        IEnumerable<AccountChart> GetAccountByType (string type);

        IEnumerable<AccountChart> GetAllOrganizationAccount (uint organizationId);
    }
}