using MAInformation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.DataAccess.Configuration
{
    public class ActorMovieConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(am => new { am.ActorId, am.MovieId });
            builder.Property(am => am.NameInMovie).HasMaxLength(40).IsRequired();
        }
    }
}
