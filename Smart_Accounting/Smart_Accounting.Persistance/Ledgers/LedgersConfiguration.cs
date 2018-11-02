/*
 * @CreateTime: Oct 18, 2018 1:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:41 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Ledgers;

namespace Smart_Accounting.Persistance.Ledgers {
    public class LedgersConfiguration : IEntityTypeConfiguration<Ledger> {
        public void Configure (EntityTypeBuilder<Ledger> builder) {
            builder.ToTable ("ledger");

            builder.HasIndex (e => e.PeriodId)
                .HasName ("fk_LEDGER_PERIOD_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.PostType)
                .HasColumnName ("post_type")
                .HasColumnType ("varchar(30)");

            builder.Property (e => e.Discription)
                .IsRequired ()
                .HasColumnName ("discription")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DocumentNo)
                .HasColumnName ("document_no")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.PeriodId).HasColumnName ("PERIOD_ID");

            builder.HasOne (d => d.Period)
                .WithMany (p => p.Ledger)
                .HasForeignKey (d => d.PeriodId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_LEDGER_PERIOD");
        }
    }
}