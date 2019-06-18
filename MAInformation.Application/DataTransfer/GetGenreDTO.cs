using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
    public class GetGenreDTO
    {
        public GetGenreDTO()
        {
            listMovies = new List<GetMovieForGenreDTO> ();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GetMovieForGenreDTO> listMovies { get; set; }
    }
}
