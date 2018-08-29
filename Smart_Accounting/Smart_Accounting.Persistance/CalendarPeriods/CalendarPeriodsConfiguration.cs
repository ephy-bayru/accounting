using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Persistance.CalendarPeriods {
    public class CalendarPeriodsConfiguration : IEntityTypeConfiguration<CalendarPeriod> {

        public void Configure (EntityTypeBuilder<CalendarPeriod> builder) {

            builder.HasKey (e => e.Id);

            builder.ToTable ("calendar_period");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)");

            builder.Property (e => e.End)
                .HasColumnName ("end")
                .HasColumnType ("date");

            builder.Property (e => e.Start)
                .HasColumnName ("start")
                .HasColumnType ("date");
        }

    }
}