using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
  public  class Language : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
