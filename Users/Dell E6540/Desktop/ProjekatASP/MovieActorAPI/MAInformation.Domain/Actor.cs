using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
  public  class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string HomeTown { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Picture { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
