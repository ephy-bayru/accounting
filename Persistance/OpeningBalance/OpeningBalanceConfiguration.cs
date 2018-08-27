namespace Smart_Accounting.Persistance.OpeningBalance
{
    public class OpeningBalanceConfiguration: EntityTypeConfiguration<OpeningBalance>
    {
        public OpeningBalanceConfiguration() {
            ToTable("OPENING_BALANCE");

                HasIndex(e => e.AccountId)
                    .HasName("fk_OPENING_BALANCE_account_idx");

                HasIndex(e => e.PeriodId)
                    .HasName("fk_OPENING_BALANCE_period_idx");

                Property(e => e.Id).HasColumnName("ID");

                Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                Property(e => e.Credit).HasColumnName("credit");

                Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                Property(e => e.Debit).HasColumnName("debit");

                Property(e => e.PeriodId).HasColumnName("PERIOD_ID");

                HasOne(d => d.Account)
                    .WithMany(p => p.OpeningBalance)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OPENING_BALANCE_account");

                HasOne(d => d.Period)
                    .WithMany(p => p.OpeningBalance)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OPENING_BALANCE_period");
        }
        
    }
}