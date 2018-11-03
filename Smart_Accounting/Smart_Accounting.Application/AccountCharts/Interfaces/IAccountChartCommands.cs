/*
 * @CreateTime: Nov 3, 2018 11:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:05 PM
 * @Description: Interface that defined the required data definition queries required
 *  for account chart domain object
 */
using System.Collections.Generic;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartCommands {

        /* Takes Argument of single AccountChart Object 
        and returns the Newly Created Account on success
        or Null on failure
        */
        AccountChart createAccount (AccountChart newAccount);

        /* Takes Argument of single AccountChart Object 
        and returns the True on success
        or false on failure
        */
        bool updateAccount(AccountChart updatedAccount);
        /*
        Deletes a single instance of Account Chart and return 
        true on successful operation or false on failure
         */
        bool deleteAccount (AccountChart account);
    }
}