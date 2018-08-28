using Microsoft.EntityFrameworkCore;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Application.Interfaces
{
    public interface IAccountingDatabaseService
    {
        DbSet<AccountChart> AccountChart { get; set; }
        DbSet<AccountType> AccountType { get; set; }
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