using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.FirstName).HasMaxLength(40).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(40).IsRequired();
            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.Country).HasMaxLength(40).IsRequired();
            builder.HasOne(a => a.Gender).WithMany(g => g.Actors).HasForeignKey(a => a.GenderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(a => a.HomeTown).HasMaxLength(40).IsRequired();
            builder.Property(a => a.Picture).HasMaxLength(40).IsRequired();
            builder.HasMany(a => a.ActorMovies).WithOne(am => am.Actor)
                .HasForeignKey(am => am.ActorId).OnDelete(DeleteBehavior.Restrict);
    }
    }
}
