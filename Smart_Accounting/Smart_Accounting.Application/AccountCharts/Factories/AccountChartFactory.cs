/*
 * @CreateTime: Sep 25, 2018 12:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 4:04 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.OpeningBalances;

namespace Smart_Accounting.Application.AccountCharts.Factories {
    public class AccountChartFactory : IAccountChartFactory {
        private readonly ICalendarPeriodQueries _period;

        public AccountChartFactory (ICalendarPeriodQueries period) {
            _period = period;
        }

        public IEnumerable<AccountChart> NewAccount (IEnumerable<NewAccountModel> newType) {
            List<AccountChart> account = new List<AccountChart> ();
    var active = _period.getActivePeriod();
            foreach (var item in newType) {
                OpeningBalance ob = new OpeningBalance(){
                    Credit = item.OpeningBalance,
                    PeriodId = item.periodId
                };
                account.Add (new AccountChart () {
                    AccountId = item.AccountId,
                    Name = item.Name,
                        AccountCode = item.AccountCode,
                        OrganizationId = item.OrganizationId,
                        Active = (sbyte)item.Active,
                        AccountType = item.AccountType,
                        OpeningBalance = new List<OpeningBalance>(){
                            new OpeningBalance() {
                                Credit =  item.OpeningBalance,
                                PeriodId = item.periodId
                            }
                        }
                        
                });
            }

            return account;
        }

        public AccountChart UpdatedAccount (UpdatedAccountModel newModel) {
            AccountChart account = new  AccountChart () {
                    AccountId = newModel.AccountId,
                    AccountType = newModel.AccountType,
                    Name = newModel.Name,
                        AccountCode = newModel.AccountCode,
                        OrganizationId = newModel.OrganizationId,
                        Active = newModel.Active

                };
        

        return account;

        }

    }
}