/*
 * @CreateTime: Sep 25, 2018 12:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:05 PM
 * @Description: Defines all the required database read functionalities
 *      on account chart domain object
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