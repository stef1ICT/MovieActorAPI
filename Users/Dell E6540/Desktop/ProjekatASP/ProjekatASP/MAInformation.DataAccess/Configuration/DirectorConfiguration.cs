using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.Property(d => d.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.FirstName).HasMaxLength(40).IsRequired();
            builder.Property(d => d.LastName).HasMaxLength(40).IsRequired();
            builder.Property(d => d.Picture).HasMaxLength(40).IsRequired();
            builder.Property(d => d.Country).HasMaxLength(40).IsRequired();
            builder.Property(d => d.HomeTown).HasMaxLength(40).IsRequired();
            builder.HasOne(d => d.Gender).WithMany(g => g.Directors).HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.Restrict);
         
    }
    }
}
