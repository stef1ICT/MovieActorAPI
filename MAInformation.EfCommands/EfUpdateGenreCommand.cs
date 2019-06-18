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
    public class EfUpdateGenreCommand : BaseEfCommand, IUpdateGenreCommand
    {
        public EfUpdateGenreCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateGenreDTO request)
        {
            var genre = _context.Genres.Find(request.Id);

            if(genre == null)
            {
                throw new EntityNotFoundException("Genre doesn't exist!");
            }

            if(_context.Genres.Any(g => g.Name.ToLower() == request.Name.ToLower().Trim()))
            {
                throw new EntityAlReadyExistException("This ganre already exist!");
            }

            genre.Name = request.Name;
            genre.ModifiedAt = DateTime.Now;
            _context.SaveChanges();

        }
    }
}
