/*
 * @CreateTime: Sep 25, 2018 12:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 25, 2018 12:12 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.AccountCharts;


namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartQueries {
        AccountChart GetById (uint accountId);
        IEnumerable<AccountChart> GetAll ();
    }
}