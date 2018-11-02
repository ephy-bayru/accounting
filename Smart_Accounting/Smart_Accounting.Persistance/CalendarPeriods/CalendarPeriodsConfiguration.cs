/*
 * @CreateTime: Nov 2, 2018 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:20 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Persistance.CalendarPeriods {
    public class CalendarPeriodsConfiguration : IEntityTypeConfiguration<CalendarPeriod> {

        public void Configure (EntityTypeBuilder<CalendarPeriod> builder) {

            builder.ToTable ("calendar_period");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Closed)
                .HasColumnName ("closed")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.End)
                .HasColumnName ("end")
                .HasColumnType ("date");

            builder.Property (e => e.IsBegining)
                .HasColumnName ("is_begining")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Start)
                .HasColumnName ("start")
                .HasColumnType ("date");
        }

    }
}