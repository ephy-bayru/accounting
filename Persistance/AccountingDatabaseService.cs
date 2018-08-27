using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Smart_Accounting.Persistance
{
    public class AccountingDatabaseService : DbContext, IAccountingDatabaseService
    {
        public AccountingDatabaseService(DbContextOptions<AccountingDatabaseService> options)
            : base(options)
        {
            DataBase.SetInitializer(new DatabaseInitializer())
        }

        public  DbSet<AccountChart> AccountChart { get; set; }
        public  DbSet<AccountType> AccountType { get; set; }
        public  DbSet<BankAccounts> BankAccounts { get; set; }
        public  DbSet<CalendarPeriod> CalendarPeriod { get; set; }
        public  DbSet<Currency> Currency { get; set; }
        public  DbSet<Customer> Customer { get; set; }
        public  DbSet<Employees> Employees { get; set; }
        public  DbSet<ExchangeRate> ExchangeRate { get; set; }
        public  DbSet<Jornal> Jornal { get; set; }
        public  DbSet<Ledger> Ledger { get; set; }
        public  DbSet<OpeningBalance> OpeningBalance { get; set; }
        public  DbSet<Organization> Organization { get; set; }
        public  DbSet<Suppliers> Suppliers { get; set; }
        public  DbSet<SystemDefaults> SystemDefaults { get; set; }
        public  DbSet<Tax> Tax { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;port=3306;database=smart_finance;");
            }
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeesConfiguration());
            modelBuilder.Configurations.Add(new AccountChartConfiguration());
            modelBuilder.Configurations.Add(new AccountTypeConfiguration());
            modelBuilder.Configurations.Add(new LedgerConfiguration());
            modelBuilder.Configurations.Add(new JornalConfiguration());
            modelBuilder.Configurations.Add(new ExchangeRateConfiguration());
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new OpeningBalanceConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new SuppliersConfiguration());
            modelBuilder.Configurations.Add(new SystemDefaultsConfiguration());
            modelBuilder.Configurations.Add(new BankAccountsConfiguration());
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
