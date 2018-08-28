using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.OpeningBalances;

namespace Smart_Accounting.Persistance.OpeningBalances {
    public class OpeningBalanceConfiguration : IEntityTypeConfiguration<OpeningBalance> {
        public void Configure (EntityTypeBuilder<OpeningBalance> builder) {
            builder.ToTable ("OPENING_BALANCE");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_OPENING_BALANCE_account_idx");

            builder.HasIndex (e => e.PeriodId)
                .HasName ("fk_OPENING_BALANCE_period_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.AccountId).HasColumnName ("ACCOUNT_ID");

            builder.Property (e => e.Credit).HasColumnName ("credit");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Debit).HasColumnName ("debit");

            builder.Property (e => e.PeriodId).HasColumnName ("PERIOD_ID");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.OpeningBalance)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_OPENING_BALANCE_account");

            builder.HasOne (d => d.Period)
                .WithMany (p => p.OpeningBalance)
                .HasForeignKey (d => d.PeriodId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_OPENING_BALANCE_period");
        }
    }
}