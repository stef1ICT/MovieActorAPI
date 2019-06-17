using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).HasMaxLength(35).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
            builder.HasOne(m => m.Director).WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Language).WithMany(l => l.Movies)
                .HasForeignKey(m => m.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.MovieActors)
                .WithOne(ma => ma.Movie).HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.MovieGenres).WithOne(mg => mg.Movie)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(m => m.Image).HasMaxLength(50).IsRequired();
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
      


    }
}
