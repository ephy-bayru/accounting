/*
 * @CreateTime: Nov 13, 2018 11:34 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 13, 2018 11:41 AM
 * @Description: Modify Here, Please 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.PostingTypes;

namespace Smart_Accounting.Persistance.PostingTypes {
    public class PostingTypeConfiguration : IEntityTypeConfiguration<PostingType> {
        public void Configure (EntityTypeBuilder<PostingType> builder) {

            builder.ToTable ("posting_type");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.Description)
                .HasColumnName ("description")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.System)
                .HasColumnName ("system")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(45)");

        }
    }

}