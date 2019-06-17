using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(g => g.Name).HasMaxLength(40).IsRequired();
            builder.HasIndex(g => g.Name).IsUnique();
            builder.HasMany(g => g.Actors).WithOne(a => a.Gender)
                .HasForeignKey(a => a.GenderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
