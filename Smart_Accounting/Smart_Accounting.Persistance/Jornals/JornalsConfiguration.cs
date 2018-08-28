using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Jornals;

namespace Smart_Accounting.Persistance.Jornals {
    public class JornalsConfiguration : IEntityTypeConfiguration<Jornal> {
        public void Configure (EntityTypeBuilder<Jornal> builder) {
            builder.ToTable ("jornal");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_jornal_account_idx");

            builder.HasIndex (e => e.CurrencyCode)
                .HasName ("fk_jornal_currency_idx");

            builder.HasIndex (e => e.Reference)
                .HasName ("fk_jornal_TRANSACTION_idx");

            builder.Property (e => e.JornalId).HasColumnName ("JORNAL_ID");

            builder.Property (e => e.AccountId).HasColumnName ("ACCOUNT_ID");

            builder.Property (e => e.Credit).HasColumnName ("credit");

            builder.Property (e => e.CurrencyCode).HasColumnName ("CURRENCY_CODE");

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

            builder.Property (e => e.Reconcied)
                .HasColumnName ("reconcied")
                .HasColumnType ("tinyint(1)");

            builder.Property (e => e.ReconcieldOn)
                .HasColumnName ("reconcield_on")
                .HasColumnType ("datetime");

            builder.Property (e => e.Reference).HasColumnName ("reference");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Jornal)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_jornal_account");

            builder.HasOne (d => d.CurrencyCodeNavigation)
                .WithMany (p => p.Jornal)
                .HasForeignKey (d => d.CurrencyCode)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_jornal_currency");

            builder.HasOne (d => d.ReferenceNavigation)
                .WithMany (p => p.Jornal)
                .HasForeignKey (d => d.Reference)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_jornal_TRANSACTION");
        }
    }
}