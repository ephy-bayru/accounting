using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Models;
using Smart_Accounting.Application.Interfaces;

namespace Smart_Accounting.Application.AccountCharts.Command {
    public class AccountChartCommands : IAccountChartCommands {

        private readonly IAccountingDatabaseService _database;
        private readonly IAccountChartCommandsFactory _accountCommandFactory;

        public AccountChartCommands(IAccountingDatabaseService database,
                                    IAccountChartCommandsFactory accountCmdFactory) {
            _database = database;
            _accountCommandFactory = accountCmdFactory;
        }

        public void create()
        {
            throw new System.NotImplementedException();
        }

        public void creatAccountType (NewAccountTypeModel newType) {

            var accountType = _accountCommandFactory.NewAccountType(newType);
            _database.AccountType.Add(accountType);
            _database.Save();

        }

        public void delete () {
            throw new System.NotImplementedException ();
        }

        public void update () {
            throw new System.NotImplementedException ();
        }
    }
}