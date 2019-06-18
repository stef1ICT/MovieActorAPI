using MAInformation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
  public  class GetDirectorDTO
    {

        public GetDirectorDTO()
        {
            Movies = new List<GetMovieDTO>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdGender { get; set; }
        public string Country { get; set; }
        public string HomeTown { get; set; }


        public List<GetMovieDTO> Movies { get; set; }
    }
}
