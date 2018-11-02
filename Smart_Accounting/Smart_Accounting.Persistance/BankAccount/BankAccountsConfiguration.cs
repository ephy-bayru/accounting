/*
 * @CreateTime: Nov 2, 2018 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:20 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain;
using Smart_Accounting.Domain.BankAccount;

namespace Smart_Accounting.Persistance.BankAccount {
    public class BankAccountsConfiguration : IEntityTypeConfiguration<BankAccounts> {

        public void Configure (EntityTypeBuilder<BankAccounts> builder) {
            builder.HasKey (e => e.BankId);

            builder.ToTable ("bank_accounts");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_bank_accounts_account_idx");

            builder.Property (e => e.BankId).HasColumnName ("BANK_ID");

            builder.Property (e => e.AccountId)
                .IsRequired ()
                .HasColumnName ("ACCOUNT_ID")
                .HasColumnType ("varchar(30)");

            builder.Property (e => e.BankAccountCode)
                .HasColumnName ("bank_account_code")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.BankCreditAccount)
                .HasColumnName ("bank_credit_account")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.BankDebitAccount)
                .HasColumnName ("bank_debit_account")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.BankAccounts)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_bank_accounts_account");
        }
    }
}