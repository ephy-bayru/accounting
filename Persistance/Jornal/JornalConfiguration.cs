namespace Smart_Accounting.Persistance.Jornal
{
    public class JornalConfiguration : EntityTypeConfiguration<Jornal>
    {
        public JornalConfiguration() {
            ToTable("jornal");

                HasIndex(e => e.AccountId)
                    .HasName("fk_jornal_account_idx");

                HasIndex(e => e.CurrencyCode)
                    .HasName("fk_jornal_currency_idx");

                HasIndex(e => e.Reference)
                    .HasName("fk_jornal_TRANSACTION_idx");

                Property(e => e.JornalId).HasColumnName("JORNAL_ID");

                Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                Property(e => e.Credit).HasColumnName("credit");

                Property(e => e.CurrencyCode).HasColumnName("CURRENCY_CODE");

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

                Property(e => e.Reconcied)
                    .HasColumnName("reconcied")
                    .HasColumnType("tinyint(1)");

                Property(e => e.ReconcieldOn)
                    .HasColumnName("reconcield_on")
                    .HasColumnType("datetime");

                Property(e => e.Reference).HasColumnName("reference");

                HasOne(d => d.Account)
                    .WithMany(p => p.Jornal)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jornal_account");

                HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.Jornal)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jornal_currency");

                HasOne(d => d.ReferenceNavigation)
                    .WithMany(p => p.Jornal)
                    .HasForeignKey(d => d.Reference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jornal_TRANSACTION");
        }
    }
}