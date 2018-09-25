/*
 * @CreateTime: Sep 25, 2018 12:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 25, 2018 12:21 PM
 * @Description: 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartFactory {
        IEnumerable<AccountChart> NewAccount (IEnumerable<NewAccountModel> newType);
        bool UpdatedAccount (IEnumerable<UpdatedAccountModel> newModel);

    }
}