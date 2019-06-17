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
    public class EfGetDirectorCommand : BaseEfCommand, IGetDirectorCommand
    {
        public EfGetDirectorCommand(MAInformationContext context) : base(context)
        {
        }

        public IEnumerable<GetDirectorDTO> Execute(DirectorSearch request)
        {
            var directors = _context.Directors.Include(d => d.Movies).AsQueryable();



            if(request.FirstName != null)
            {
            directors =    directors.Where(d => d.FirstName.ToLower().Contains(request.FirstName.Trim().ToLower()));
            }
            if (request.LastName != null)
            {
               directors = directors.Where(d => d.LastName.ToLower().Contains(request.LastName.Trim().ToLower()));
            }


            if (request.Country != null)
            {
            directors =    directors.Where(d => d.Country.ToLower().Contains(request.Country.Trim().ToLower()));
            }

            if (request.HomeTown != null)
            {
             directors =   directors.Where(d => d.HomeTown.ToLower().Contains(request.HomeTown.Trim().ToLower()));
            }

            if (request.GenderId != null)
            {
                directors = directors.Where(d => d.IdGender == request.GenderId);
            }

            if(request.Id != null)
            {
                directors = directors.Where(d => d.Id == request.Id);
            }


            if(request.DateBirthStart != DateTime.MinValue)
            {
                directors = directors.Where(d => d.DateOfBirth >= request.DateBirthStart);
            }

            if (request.DateBirthEnd != DateTime.MinValue)
            {
                directors = directors.Where(d => d.DateOfBirth <= request.DateBirthEnd);
            }

    

            return directors.Select(d => new GetDirectorDTO
            {
                Country = d.Country,
                DateOfBirth = d.DateOfBirth,
                FirstName = d.FirstName,
                HomeTown = d.HomeTown,
                IdGender = d.IdGender,
                LastName = d.LastName,
                Picture = d.Picture,
                Movies = d.Movies.Select(m => new GetMovieDTO {
                    Description = m.Description,
                    Director = m.Director.FirstName + " " + m.Director.LastName,
                    Duration = m.Duration,
                    Image = m.Image,
                    ImdbRating = m.ImdbRating,
                    Language = m.Language.Name,
                    PremiereDate = m.PremiereDate,
                    Id = m.Id,
                    Title = m.Title
                }).ToList()
            }).ToList();
        }
    }
}
;