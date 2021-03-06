using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Jornals;

namespace Smart_Accounting.Persistance.Jornals {
    public class JornalsConfiguration : IEntityTypeConfiguration<Jornal> {
        public void Configure (EntityTypeBuilder<Jornal> builder) {
            builder.ToTable ("jornal");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_jornal_account_idx");

            builder.HasIndex (e => e.LedgerId)
                .HasName ("fk_jornal_ledger_id_idx");

            builder.HasIndex (e => e.PostingType)
                .HasName ("fk_jornal_posting_type_idx");

            builder.Property (e => e.JornalId).HasColumnName ("JORNAL_ID");

            builder.Property (e => e.AccountId)
                .IsRequired ()
                .HasColumnName ("ACCOUNT_ID")
                .HasColumnType ("varchar(30)");

            builder.Property (e => e.Amount).HasColumnName ("amount");

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

            builder.Property (e => e.ExchangeRate).HasColumnName ("exchange_rate");

            builder.Property (e => e.LedgerId).HasColumnName ("LEDGER_ID");

            builder.Property (e => e.PostingEntityId).HasColumnName ("posting_entity_id");

            builder.Property (e => e.PostingType).HasColumnName ("posting_type");

            builder.Property (e => e.ReconcieldOn)
                .HasColumnName ("reconcield_on")
                .HasColumnType ("datetime");

            builder.Property (e => e.Reconciled)
                .HasColumnName ("reconciled")
                .HasColumnType ("tinyint(1)");

            builder.Property (e => e.Reference)
                .HasColumnName ("reference")
                .HasColumnType ("varchar(30)");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Jornal)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_jornal_account");

            builder.HasOne (d => d.PostingTypeNavigation)
                .WithMany (p => p.Jornal)
                .HasForeignKey (d => d.PostingType)
                .HasConstraintName ("fk_jornal_posting_type");
        }
    }
}