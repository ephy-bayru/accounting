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
    public class AccountChartFactory : IAccountChartFactory {

        public AccountChartFactory () {

        }

        public IEnumerable<AccountChart> NewAccount (IEnumerable<NewAccountModel> newType) {
            List<AccountChart> account = new List<AccountChart> ();

            foreach (var item in newType) {
                account.Add (new AccountChart () {
                    Name = item.Name,
                        AccountCode = item.AccountCode,
                        OrganizationId = item.OrganizationId,
                        Active = item.Active

                });
            }

            return account;
        }

        public AccountChart UpdatedAccount (UpdatedAccountModel newModel) {
            AccountChart account = new  AccountChart () {
                    Name = newModel.Name,
                        AccountCode = newModel.AccountCode,
                        OrganizationId = newModel.OrganizationId,
                        Active = newModel.Active

                };
        

        return account;

        }

    }
}