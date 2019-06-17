using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
   public class Gender : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
    }
}
