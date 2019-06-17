using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
    public class GetActorDTO
    {

        public GetActorDTO()
        {
            Movies = new List<GetMovieForActorDTO>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public int? GenderId { get; set; }
        public string HomeTown { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Picture { get; set; }

        public List<GetMovieForActorDTO>  Movies { get; set; }
    }
}
