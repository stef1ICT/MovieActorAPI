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
    public class EfDeleteGenreMovieRelationCommand : BaseEfCommand, IDeleteMovieGenreRelationCommand
    {
        public EfDeleteGenreMovieRelationCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(GanreMovieRelationDTO request)
        {
            var movie = _context.Movies.Find(request.MovieId);
            var genre = _context.Genres.Find(request.GanreId);


            if(movie == null || genre == null)
            {
                throw new EntityNotFoundException("Movie or genre doesn't exist!");
            }


            var relation = _context.MovieGenre.Where(x => x.GenreId == request.GanreId && x.MovieId == request.MovieId).FirstOrDefault();
            if(relation == null)
            {
                throw new RelationDoesntExistException("This relation doesn't exist!");
            }

            _context.Remove(relation);

            _context.SaveChanges();
        }
    }
}
