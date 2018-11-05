/*
 * @CreateTime: Sep 25, 2018 12:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:36 PM
 * @Description: Used to convert between Dto objects and domain object 
 *          and implements the IAccountChartFactory
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

        public AccountChart NewAccount (NewAccountModel newType) {
                var activePeriod = _period.getActivePeriod ();

            return new AccountChart () {
                AccountId = newType.AccountId,
                    Name = newType.Name,
                    AccountCode = newType.AccountCode,
                    OrganizationId = newType.OrganizationId,
                    Active = (newType.Active == 1) ? (sbyte)  1 : (sbyte)  0 ,
                    AccountType = newType.AccountType,
                    IsReconcilation = (newType.IsReconcilation == 1) ? (sbyte)  1 : (sbyte)  0 ,
                    DirectPositng = (newType.IsPosting == 1) ? (sbyte)  1 : (sbyte)  0 ,
                    GlType = newType.GlType,
                    Type = newType.PostingType,
                    OpeningBalance = new List<OpeningBalance> () {
                        new OpeningBalance () {
                        Credit = newType.OpeningBalance,
                        PeriodId = activePeriod.Id
                        }
                    }

            };

        }

        public AccountChart UpdatedAccount (UpdatedAccountModel newModel) {
            AccountChart account = new AccountChart () {
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