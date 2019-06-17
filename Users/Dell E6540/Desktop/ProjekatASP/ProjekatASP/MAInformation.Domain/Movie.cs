using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
   public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public double ImdbRating { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Image { get; set; }
        public int Duration { get; set; }
        public DateTime PremiereDate { get; set; }

        public ICollection<ActorMovie> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
