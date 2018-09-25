using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Domain.Employe;
using Smart_Accounting.Domain.AccountCharts;
using Smart_Accounting.Domain.BankAccount;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Domain.Currencies;
using Smart_Accounting.Domain.Customers;
using Smart_Accounting.Domain.ExchangeRates;
using Smart_Accounting.Domain.Jornals;
using Smart_Accounting.Domain.Ledgers;
using Smart_Accounting.Domain.OpeningBalances;
using Smart_Accounting.Domain.Oranizations;
using Smart_Accounting.Domain.Supplier;
using Smart_Accounting.Domain.SystemDefault;
using Smart_Accounting.Domain.Taxes;

namespace Smart_Accounting.Application.Interfaces
{
    public interface IAccountingDatabaseService
    {
        DbSet<AccountChart> AccountChart { get; set; }
        DbSet<BankAccounts> BankAccounts { get; set; }
        DbSet<CalendarPeriod> CalendarPeriod { get; set; }
        DbSet<Currency> Currency { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Employees> Employees { get; set; }
        DbSet<ExchangeRate> ExchangeRate { get; set; }
        DbSet<Jornal> Jornal { get; set; }
        DbSet<Ledger> Ledger { get; set; }
        DbSet<OpeningBalance> OpeningBalance { get; set; }
        DbSet<Organization> Organization { get; set; }
        DbSet<Suppliers> Suppliers { get; set; }
        DbSet<SystemDefaults> SystemDefaults { get; set; }
        DbSet<Tax> Tax { get; set; }

        void Save();
        
    }
}