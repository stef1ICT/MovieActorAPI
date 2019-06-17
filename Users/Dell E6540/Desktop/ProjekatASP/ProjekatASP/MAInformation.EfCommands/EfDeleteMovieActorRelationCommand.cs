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
    public class EfDeleteMovieActorRelationCommand : BaseEfCommand, IDeleteMovieActorRelationCommand
    {
        public EfDeleteMovieActorRelationCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(MovieActorDeleteDTO request)
        {
            var movie = _context.Movies.Find(request.MovieId);
            var actor = _context.Actors.Find(request.ActorId);


            if(movie == null || actor == null)
            {
                throw new EntityNotFoundException("Actor or Movie doesn't exist!");
            }

            var Relation = _context.ActorMovie.Where(x => x.MovieId == request.MovieId && x.ActorId == request.ActorId).FirstOrDefault();
            if(Relation ==null)
            {
                throw new EntityNotFoundException("You want to delete unexisten entity");
            }

            var ActorMovie = _context.ActorMovie.Where(x => x.ActorId == request.ActorId && x.MovieId == x.MovieId).FirstOrDefault();
            _context.ActorMovie.Remove(ActorMovie);
            _context.SaveChanges();
        }
    }
}
