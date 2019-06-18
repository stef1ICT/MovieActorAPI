using MAInformation.Application.Commands;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfDeleteGenreCommand : BaseEfCommand, IDeleteGenreCommand
    {
        public EfDeleteGenreCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(int request)
        {

            var genre = _context.Genres.Find(request);

            if(genre == null)
            {
                throw new EntityNotFoundException("This genre not found");
            }
           
            if(_context.Genres.Any(x => x.GenreMovies.Any(gm => gm.GenreId == request))) {
                throw new GenreHasMoviesException("This genre has movie, you can't delete it.");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }
    }
}
