namespace Smart_Accounting.Persistance.BankAccount
{
    public class BankAccountConfiguration : EntityTypeConfiguration<BankAccount>
    {
        public BankAccountConfiguration()  {
                HasKey(e => e.BankId);

                ToTable("bank_accounts");

                HasIndex(e => e.AccountId)
                    .HasName("fk_bank_accounts_ID_idx");

                Property(e => e.BankId).HasColumnName("BANK_ID");

                Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                Property(e => e.BankAccountCode)
                    .HasColumnName("bank_account_code")
                    .HasColumnType("varchar(45)");

                Property(e => e.BankCreditAccount)
                    .HasColumnName("bank_credit_account")
                    .HasColumnType("varchar(45)");

                Property(e => e.BankDebitAccount)
                    .HasColumnName("bank_debit_account")
                    .HasColumnType("varchar(45)");

                Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                HasOne(d => d.Account)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bank_accounts_ID");
        }
    }
}