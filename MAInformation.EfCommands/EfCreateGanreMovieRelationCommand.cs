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
    public class EfCreateGanreMovieRelationCommand : BaseEfCommand, IAddMovieGanreRelationCommand
    {
        public EfCreateGanreMovieRelationCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(GanreMovieRelationDTO request)
        {
            var movie = _context.Movies.Find(request.MovieId);

            var ganre = _context.Genres.Find(request.GanreId);


            if(movie == null || ganre == null)
            {
                throw new EntityNotFoundException("Movie or ganre doesn't exist!");
            }


            var AlreadyExistGanreMovie = _context.MovieGenre.Where(x => x.GenreId == request.GanreId && x.MovieId == request.MovieId).FirstOrDefault();

            if(AlreadyExistGanreMovie != null)
            {
                throw new RelationAlreadyExistException("Movie already has this ganre");
            }


            _context.MovieGenre.Add(new MovieGenre
            {
                GenreId = (int)request.GanreId,
                MovieId = (int)request.MovieId
            });
            _context.SaveChanges();
        }
    }
}
