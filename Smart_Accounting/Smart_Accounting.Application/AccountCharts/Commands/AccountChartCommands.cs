/*
 * @CreateTime: Nov 3, 2018 11:56 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 12:02 PM
 * @Description: Used to perform Account Chart related database definition 
 *             i.e. queries Add, Update & Delete
 */
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Application.AccountCharts.Command {
    public class AccountChartCommands : IAccountChartCommands {
        private readonly ILogger<AccountChartCommands> _logger;
        private readonly IAccountingDatabaseService _database;

        public AccountChartCommands (IAccountingDatabaseService database,
            ILogger<AccountChartCommands> logger) {
            _logger = logger;
            _database = database;
        }

        public bool deleteAccount (AccountChart account) {
            try {
                _database.AccountChart.Remove (account);
                _database.Save ();
                return true;
            } catch (Exception e) {
                _logger.LogError (500, e.Message);
                throw;
            }

        }

        public AccountChart createAccount (AccountChart newAccount) {
            try {
                _database.AccountChart.Add (newAccount);
                _database.Save ();
                return newAccount;

            } catch (Exception e) {
                _logger.LogError (500, e.Message);
                return null;

                throw;
            }

        }

        public bool updateAccount (AccountChart updatedAccount) {
            _database.AccountChart.Update (updatedAccount);
            _database.Save ();
            return true;
        }
    }
}