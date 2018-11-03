/*
 * @CreateTime: Sep 25, 2018 12:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:06 PM
 * @Description: Used to convert between Dto objects and domain object 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartFactory {
        // Takes DTO Object And Convert is to Account Chart Domain Object
        // for new account dto object
        AccountChart NewAccount (NewAccountModel newType);
        // Takes DTO Object And Convert is to Account Chart Domain Object
        // for Updated account dto object
        AccountChart UpdatedAccount (UpdatedAccountModel newModel);

    }
}