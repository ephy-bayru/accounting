using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain;

namespace Smart_Accounting.Persistance.Account.AccountTypes {
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType> {

        public void Configure (EntityTypeBuilder<AccountType> builder) {
            builder.HasKey (e => e.AccTypeId);

            builder.ToTable ("account_type");

            builder.Property (e => e.AccTypeId).HasColumnName ("acc_type_id");

            builder.Property (e => e.Active)
                .IsRequired ()
                .HasColumnName ("active")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(100)");
        }
    }
}