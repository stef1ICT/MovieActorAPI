using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Searches
{
   public class ActorSearch
    {
        public int? Id { get; set; }

        public DateTime? StartDateOfBirth { get; set; }
        public DateTime? EndDateOfBirth { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int? GenderId { get; set; }
        public string HomeTown { get; set; }
        public double? StartHeight { get; set; }
        public double? EndHeight { get; set; }
        public double? StartWeight { get; set; }
        public double? EndWeight { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}
