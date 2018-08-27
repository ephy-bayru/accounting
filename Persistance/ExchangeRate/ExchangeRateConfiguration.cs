namespace Smart_Accounting.Persistance.ExchangeRate
{
    public class ExchangeRateConfiguration : EntityTypeConfiguration<ExchangeRate> 
    {
        public ExchangeRateConfiguration()
    {
            
            ToTable("CUSTOMER");

                HasIndex(e => e.AccountId)
                    .HasName("fk_CUSTOMER_account_idx");

                Property(e => e.Id).HasColumnName("ID");

                Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                Property(e => e.CreditLimit).HasColumnName("credit_limit");

                Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime");

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                HasOne(d => d.Account)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CUSTOMER_account");
        }
    }
}