using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfUpdateMovieCommand : BaseEfCommand, IUpdateMovieCommand
    {
        public EfUpdateMovieCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateMovieDTO request)
        {

            var movie = _context.Movies.Find(request.Id);


            if(movie == null)
            {
                throw new EntityNotFoundException("Movie");
            }

            if (request.ImdbRating < 0 && request.ImdbRating > 10)
            {
                throw new BadValueException("Imdb Rating");
            }


            if (request.PremiereDate == DateTime.MinValue)
            {
                throw new BadValueException("Premiere Date");
            }


            if (!_context.Languages.Any(l => l.Id == request.LanguageId))
            {
                throw new EntityNotFoundException("Language");
            }

            if (!_context.Directors.Any(d => d.Id == request.DirectorId))
            {
                throw new EntityNotFoundException("Director");
            }


            movie.Description = request.Description;
            movie.DirectorId = request.DirectorId;
            movie.Duration = request.Duration;
            movie.Image = request.Image;
            movie.ModifiedAt = DateTime.Now;
            movie.PremiereDate = request.PremiereDate;
            movie.LanguageId = request.LanguageId;
            movie.Title = request.Title;

            _context.SaveChanges();
        }
    }
}
