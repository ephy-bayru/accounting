using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.Customers;
using Smart_Accounting.Persistance.Account.AccountTypes;
using Smart_Accounting.Persistance.AccountCharts;
using Smart_Accounting.Persistance.BankAccount;
using Smart_Accounting.Persistance.Currencys;
using Smart_Accounting.Persistance.Customers;
using Smart_Accounting.Persistance.Defaults;
using Smart_Accounting.Persistance.Employee;
using Smart_Accounting.Persistance.ExchangeRates;
using Smart_Accounting.Persistance.Jornals;
using Smart_Accounting.Persistance.Ledgers;
using Smart_Accounting.Persistance.OpeningBalances;
using Smart_Accounting.Persistance.Organizations;
using Smart_Accounting.Persistance.Supplier;

namespace Smart_Accounting.Persistance
{
    public class AccountingDatabaseService : DbContext, IAccountingDatabaseService
    {
        public AccountingDatabaseService(DbContextOptions<AccountingDatabaseService> options)
            : base(options)
        {
         //   DataBase.SetInitializer(new AccountingDatabaseInitializer());
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
       public  DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;port=3306;database=smart_finance;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountChartConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LedgerConfiguration());
            modelBuilder.ApplyConfiguration(new JornalConfiguration());
            modelBuilder.ApplyConfiguration(new ExchangeRateConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new OpeningBalanceConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());
            modelBuilder.ApplyConfiguration(new SystemDefaultsConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
