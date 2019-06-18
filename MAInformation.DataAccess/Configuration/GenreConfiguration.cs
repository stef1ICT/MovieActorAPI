using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.Name).HasMaxLength(40).IsRequired();
           
            builder.HasMany(g => g.GenreMovies)
                .WithOne(gm => gm.Genre).HasForeignKey(gm => gm.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
