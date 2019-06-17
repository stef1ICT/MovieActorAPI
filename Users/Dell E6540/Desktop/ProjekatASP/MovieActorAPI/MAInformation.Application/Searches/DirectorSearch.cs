using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Searches
{
    public class DirectorSearch 
    {
        public int? Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirthStart { get; set; }
        public DateTime DateBirthEnd { get; set; }
        public int? GenderId { get; set; }
        public string Country { get; set; } 
        public string HomeTown { get; set; }

    }
}
