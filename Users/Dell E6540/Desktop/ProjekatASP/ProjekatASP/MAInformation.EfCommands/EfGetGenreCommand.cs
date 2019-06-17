using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Searches;
using MAInformation.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfGetGenreCommand : BaseEfCommand, IGetGenreCommand
    {
        public EfGetGenreCommand(MAInformationContext context) : base(context)
        {
        }

        public IEnumerable<GetGenreDTO> Execute(GenreSearch request)
        {

            var genre = _context.Genres.Include(x => x.GenreMovies).ThenInclude(x => x.Movie).AsQueryable();

            if(request.Id != null)
            {
                genre = genre.Where(x => x.Id == request.Id);
            }

            if(request.Name != null)
            {
                genre = genre.Where(x => x.Name.ToLower().Contains(request.Name.Trim().ToLower()));
            }


            return genre.Select(x => new GetGenreDTO
            {
                Id = x.Id,
                Name = x.Name,
                listMovies = x.GenreMovies.Select(gm => new GetMovieForGenreDTO {
                    Id = gm.Movie.Id,
                    Description = gm.Movie.Description,
                    Director = gm.Movie.Director.FirstName + " " + gm.Movie.Director.LastName,
                    Duration = gm.Movie.Duration,
                    Image = gm.Movie.Image,
                    ImdbRating = gm.Movie.ImdbRating,
                    Language = gm.Movie.Language.Name,
                    PremiereDate = gm.Movie.PremiereDate,
                    Title = gm.Movie.Title
                }).ToList()
            }).ToList();
        }
    }
}
