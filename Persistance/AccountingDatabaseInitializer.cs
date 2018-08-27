using System;

namespace Smart_Accounting.Persistance
{
    public class AccountingDatabaseInitializer
    : CreateDatabaseIfNotExists<AccountingDatabaseService>
    {
        public InventoryDatabaseInitializer() {}

        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);
            CreateCustomers(database);
            CreateEmployees(database);
            CreateLedger(database);
            CreateJornal(database);
            CreateExchangeRate(database);
            CreateCurrency(database);
            CreateOrganization(database);
            CreateCalendarPeriod(database);
            CreateBankAccount(database);
            CreateOpeningBalance(database);
            CreateSuppliers(database);
            CreateSystemDefaults(database);
            CreateCalendarPeriod(database);
        }

        public CreateCustomers(DatabaseService database)
        {
            //database.Customer.Add(new Customer() { Name = "Martin Fowler" });       
            //database.SaveChanges();
        }

        public CreateEmployees(DatabaseService database) {
            //database.Employees.Add(new Employees() {})
            //database.SaveChanges();
        }

        public CreateSuppliers(DatabaseService database) {
            //database.Suppliers.Add(new Suppliers() {})
            //database.SaveChanges();
        }

        public CreateAccountType(DatabaseService database) {
            //database.AccountType.Add(new AccountType() {})
            //database.SaveChanges();
        }

        public CreateAccountChart(DatabaseService database) {
            //database.AccountChart.Add(new AccountChart() {})
            //database.SaveChanges();
        }

        public CreateJornal(DatabaseService database) {
            //database.Jornal.Add(new Jornal() {})
            //database.SaveChanges();
        }

        public CreateLedger(DatabaseService database) {
            //database.Ledger.Add(new Ledger() {})
            //database.SaveChanges();
        }

        public CreateCalendarPeriod(DatabaseService database) {
            //database.CalendarPeriod.Add(new CalendarPeriod() {})
            //database.SaveChanges();
        }

        public CreateTax(DatabaseService database) {
            //database.Tax.Add(new Tax() {})
            //database.SaveChanges();
        }
        public CreateSystemDefaults(DatabaseService database) {
            //database.SystemDefaults.Add(new SystemDefaults() {})
            //database.SaveChanges();
        }

        public CreateExchangeRate(DatabaseService database) {
            //database.ExchangeRate.Add(new ExchangeRate() {})
            //database.SaveChanges();
        }

        public CreateCurrency(DatabaseService database) {
            //database.Currency.Add(new Currency() {})
            //database.SaveChanges();
        }

        public CreateBankAccount(DatabaseService database) {
            //database.BankAccount.Add(new BankAccount() {})
            //database.SaveChanges();
        }

        public CreateOrganization(DatabaseService database) {
            //database.Organization.Add(new Organization() {})
            //database.SaveChanges();
        }

        public CreateOpeningBalance(DatabaseService database) {
            //database.OpeningBalance.Add(new OpeningBalance() {})
            //database.SaveChanges();
        }
    }
}
