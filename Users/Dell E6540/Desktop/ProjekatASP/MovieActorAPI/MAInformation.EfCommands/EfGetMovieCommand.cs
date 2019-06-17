using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Interfaces;
using MAInformation.Application.Responses;
using MAInformation.Application.Searches;
using MAInformation.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfGetMovieCommand : BaseEfCommand, IGetMovieCommand, IGetMovieMVCDTO
    {
        public EfGetMovieCommand(MAInformationContext context) : base(context)
        {
        }

        

        public CreateMovieDTO Execute(int id)
        {
            var movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
            var movieCreateDTO = new CreateMovieDTO
            {
                Description = movie.Description,
                DirectorId = movie.DirectorId,
                Image = movie.Image,
                ImdbRating = movie.ImdbRating,
                Duration = movie.Duration,
                LanguageId = movie.LanguageId,
                PremiereDate = movie.PremiereDate,
                Title = movie.Title
            };
            return movieCreateDTO;
        }

        PagedResponse<GetMovieDTO> ICommand<MovieSearch, PagedResponse<GetMovieDTO>>.Execute(MovieSearch request)
        {
            var movies = _context.Movies.Include(m => m.MovieActors)
               .ThenInclude(ma => ma.Actor).Include(m => m.MovieGenres).ThenInclude(ma => ma.Genre).AsQueryable();

            if (request.Id.HasValue)
            {
                movies = movies.Where(m => m.Id == request.Id);
            }
            if (request.Title != null)
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(request.Title.ToLower().Trim()));
            }
            if (request.DirectorId.HasValue)
            {
                movies = movies.Where(m => m.DirectorId == request.DirectorId);
            }
            if (request.ImdbRatingMin.HasValue)
            {
                movies = movies.Where(m => m.ImdbRating >= request.ImdbRatingMin);
            }


            if (request.ImdbRatingMax.HasValue)
            {
                movies = movies.Where(m => m.ImdbRating <= request.ImdbRatingMin);
            }


            if (request.LanguageId.HasValue)
            {
                movies = movies.Where(m => m.LanguageId <= request.LanguageId);
            }


            if (request.DurationMin.HasValue)
            {
                movies = movies.Where(m => m.Duration >= request.DurationMin);
            }


            if (request.DurationMax.HasValue)
            {
                movies = movies.Where(m => m.Duration >= request.DurationMax);
            }


            if (request.PremiereDateMin != DateTime.MinValue)
            {
                movies = movies.Where(m => m.PremiereDate >= request.PremiereDateMin);
            }

            if (request.PremiereDateMax != DateTime.MinValue)
            {
                movies = movies.Where(m => m.PremiereDate <= request.PremiereDateMax);
            }
            var totalCount = movies.Count();

            movies = movies.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var data = movies.Select(m => new GetMovieDTO
            {
                PremiereDate = m.PremiereDate,
                Description = m.Description,
                Director = m.Director.FirstName + " " + m.Director.LastName,
                Duration = m.Duration,
                Id = m.Id,
                Image = m.Image,
                ImdbRating = m.ImdbRating,
                Language = m.Language.Name,
                Title = m.Title,
                actors = m.MovieActors.Select(ma => new GetActorForMovie
                {
                    Country = ma.Actor.Country,
                    FirstName = ma.Actor.FirstName,
                    Gender = ma.Actor.Gender.Name,
                    Height = ma.Actor.Height,
                    Weight = ma.Actor.Weight,
                    LastName = ma.Actor.LastName,
                    DateOfBirth = ma.Actor.DateOfBirth,
                    HomeTown = ma.Actor.HomeTown,
                    Id = ma.Actor.Id,
                    NameInMovie = ma.NameInMovie,
                    Picture = ma.Actor.Picture
                }).ToList()

            }).ToList();

            var response = new PagedResponse<GetMovieDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = data
            };
            return response;
        }
    }
}
