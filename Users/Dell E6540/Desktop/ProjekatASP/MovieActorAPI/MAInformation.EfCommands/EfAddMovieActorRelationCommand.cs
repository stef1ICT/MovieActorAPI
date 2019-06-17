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
    public class EfAddMovieActorRelationCommand : BaseEfCommand, IMovieActorRelationCommand
    {
        public EfAddMovieActorRelationCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(MovieAndActorRelationDTO request)
        {


            var movie = _context.Movies.Find(request.MovieId);
            var actor = _context.Actors.Find(request.ActorId);


            if(movie == null || actor == null)
            {
                throw new EntityNotFoundException("Movie or actor doesn't exist");
            }


            if(_context.ActorMovie.Any(x => x.ActorId == request.ActorId && x.MovieId == request.MovieId))
            {
                throw new EntityAlReadyExistException("This actor already in movie ");
            }

            _context.ActorMovie.Add(new ActorMovie
            {
                MovieId = request.MovieId,
                ActorId = request.ActorId,
                NameInMovie = request.NameInMovie
            });
            _context.SaveChanges();
        }
    }
}
