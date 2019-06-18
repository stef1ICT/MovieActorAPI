using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using MAInformation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfCreateMovieCommand : BaseEfCommand, IAddMovieCommand
    {
        public EfCreateMovieCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateMovieDTO request)
        {
            if(request.ImdbRating < 0 && request.ImdbRating > 10)
            {
                throw new BadValueException("Imdb Rating");
            }


            if(request.PremiereDate == DateTime.MinValue)
            {
                throw new BadValueException("Premiere Date");
            }


           if(!_context.Languages.Any(l => l.Id == request.LanguageId))
            {
                throw new EntityNotFoundException("Language");
            }

           if(!_context.Directors.Any(d => d.Id == request.DirectorId))
            {
                throw new EntityNotFoundException("Director");
            }


            _context.Movies.Add(new Movie
            {
                LanguageId = request.LanguageId,
                CreatedAt = DateTime.Now,
                Description = request.Description,
                DirectorId = request.DirectorId,
                Duration = request.Duration,
                Image = request.Image,
                ImdbRating = request.ImdbRating,
                PremiereDate = request.PremiereDate,
                Title = request.Title
            });

            _context.SaveChanges();
        }
    }
}
