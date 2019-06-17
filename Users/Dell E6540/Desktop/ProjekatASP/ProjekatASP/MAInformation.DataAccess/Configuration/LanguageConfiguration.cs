using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasIndex(l => l.Name).IsUnique();
            builder.Property(l => l.Name).HasMaxLength(30).IsRequired();
            builder.HasMany(l => l.Movies).WithOne(l => l.Language)
                .HasForeignKey(l => l.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(l => l.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
