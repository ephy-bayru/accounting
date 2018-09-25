/*
 * @CreateTime: Sep 25, 2018 12:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 25, 2018 12:20 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Commands {
    public class AccountChartCommandsFactory : IAccountChartCommandsFactory {
        public AccountChart NewAccount (IEnumerable<NewAccountModel> newType) {
            throw new System.NotImplementedException ();
        }

        public AccountChart UpdatedAccount (IEnumerable<UpdatedAccountModel> newModel) {
            throw new System.NotImplementedException ();
        }
    }
}