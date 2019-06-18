using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Searches
{
  public  class MovieSearch
    {

        public int? Id { get; set; }
        public string Title { get; set; }
        public int? DirectorId { get; set; }
        public double? ImdbRatingMin { get; set; }
        public double? ImdbRatingMax { get; set; }
        public int? LanguageId { get; set; }
        public int? DurationMin { get; set; }
        public int? DurationMax { get; set; }
        public DateTime PremiereDateMin { get; set; }
        public DateTime PremiereDateMax { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;

    }
}
