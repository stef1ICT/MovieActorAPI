using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
  public   class Genre : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MovieGenre> GenreMovies { get; set; }
    }
}
