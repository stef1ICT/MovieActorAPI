using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
    public class Director : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdGender { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public string HomeTown { get; set; }


        public ICollection<Movie> Movies { get; set; }
    }
}
