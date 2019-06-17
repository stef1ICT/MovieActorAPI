using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
   public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
        public string NameInMovie { get; set; }

    }
}
