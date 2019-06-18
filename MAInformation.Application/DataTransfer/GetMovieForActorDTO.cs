using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
    public class GetMovieForActorDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public double ImdbRating { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
        public int Duration { get; set; }
        public DateTime PremiereDate { get; set; }
        public string NameInMovie { get; set; }
    }
}
