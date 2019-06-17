using MAInformation.Application.Commands;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfDeleteMovieCommand : BaseEfCommand, IDeleteMovieCommand
    {
        public EfDeleteMovieCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var movie = _context.Movies.Find(request);

            if(movie == null )
            {
                throw new EntityNotFoundException("Movie");
            }


            _context.Remove(movie);


            _context.SaveChanges();
        }
    }
}
