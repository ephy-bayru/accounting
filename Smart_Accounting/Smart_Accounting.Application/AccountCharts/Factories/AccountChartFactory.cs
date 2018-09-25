/*
 * @CreateTime: Sep 25, 2018 12:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 25, 2018 12:22 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Factories {
    public class AccountChartFactory : IAccountChartCommandsFactory {

        public AccountChartFactory () {

        }

        public AccountChart NewAccount (IEnumerable<NewAccountModel> newType) {
            AccountChart account = new AccountChart ();

      
            throw new System.NotImplementedException ();
        }

        public AccountChart UpdatedAccount (IEnumerable<UpdatedAccountModel> newModel) {
            throw new System.NotImplementedException ();
        }

    }
}