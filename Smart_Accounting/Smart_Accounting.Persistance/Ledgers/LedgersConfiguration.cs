using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Persistance.Ledgers
{
    public class LedgersConfiguration : IEntityTypeConfiguration<Ledger> 
    {
        public void Configure(EntityTypeBuilder<Ledger> builder)
        {   
            builder.ToTable("LEDGER");

                builder.HasIndex(e => e.PeriodId)
                    .HasName("fk_LEDGER_PERIOD_idx");

                builder.Property(e => e.Id).HasColumnName("ID");

                builder.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                builder.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime");

                builder.Property(e => e.Discription)
                    .IsRequired()
                    .HasColumnName("discription")
                    .HasColumnType("varchar(45)");

                builder.Property(e => e.PeriodId).HasColumnName("PERIOD_ID");

                builder.HasOne(d => d.Period)
                    .WithMany(p => p.Ledger)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LEDGER_PERIOD");
        }
    }
}