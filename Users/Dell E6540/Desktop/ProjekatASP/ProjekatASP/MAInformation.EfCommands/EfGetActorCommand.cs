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
    public class EfGetActorCommand : BaseEfCommand, IGetActors
    {
        public EfGetActorCommand(MAInformationContext context) : base(context)
        {
        }

        public PagedResponse<GetActorDTO> Execute(ActorSearch request)
        {
            var actors = _context.Actors.Include(a => a.ActorMovies).ThenInclude(am => am.Movie).AsQueryable();

            if (request.StartDateOfBirth.HasValue)
            {
                actors = actors.Where(a => a.DateOfBirth >= request.StartDateOfBirth);
            }

            if (request.EndDateOfBirth.HasValue)
            {
                actors = actors.Where(a => a.DateOfBirth <= request.EndDateOfBirth);
            }
            if (request.Id != null)
            {
                actors = actors.Where(a => a.Id == request.Id);
            }


            if (request.FirstName != null)
            {
                actors = actors.Where(a => a.FirstName.ToLower().Contains(request.FirstName.Trim().ToLower()));
            }


            if (request.LastName != null)
            {
                actors = actors.Where(a => a.LastName.ToLower().Contains(request.LastName.Trim().ToLower()));
            }

            if (request.Country != null)
            {
                actors = actors.Where(a => a.Country.ToLower().Contains(request.Country.Trim().ToLower()));
            }




            if (request.GenderId != null)
            {
                actors = actors.Where(a => a.GenderId == request.GenderId);
            }


            if (request.HomeTown != null)
            {
                actors = actors.Where(a => a.HomeTown.ToLower().Contains(request.HomeTown.Trim().ToLower()));
            }

            if (request.StartHeight != null)
            {
                actors = actors.Where(a => a.Height >= request.StartHeight);
            }

            if (request.EndHeight != null)
            {
                actors = actors.Where(a => a.Height <= request.EndHeight);
            }

            if (request.StartWeight != null)
            {
                actors = actors.Where(a => a.Weight >= request.StartWeight);
            }


            if (request.EndHeight != null)
            {
                actors = actors.Where(a => a.Weight <= request.EndWeight);
            }


            var totalCount = actors.Count();

            actors = actors.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);


            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var data =  actors.Select(a => new GetActorDTO
            {
                Id = a.Id,
                DateOfBirth = a.DateOfBirth,
                FirstName = a.FirstName,
                Gender = a.Gender.Name,
                Height = a.Height,
                GenderId = a.Gender.Id,
                HomeTown = a.HomeTown,
                LastName = a.LastName,
                Picture = a.Picture,
                Weight = a.Weight,
                Country = a.Country,
                Movies = a.ActorMovies.Select(am => new GetMovieForActorDTO
                {
                    Description = am.Movie.Description,
                    Director = am.Movie.Director.FirstName + " " + am.Movie.Director.LastName,
                    Duration = am.Movie.Duration,
                    Id = am.Movie.Id,
                    Image = am.Movie.Image,
                    ImdbRating = am.Movie.ImdbRating,
                    Language = am.Movie.Language.Name,
                    PremiereDate = am.Movie.PremiereDate,
                    Title = am.Movie.Title,
                    NameInMovie = am.NameInMovie
                }).ToList()
            }).ToList();

            var response = new PagedResponse<GetActorDTO>
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
