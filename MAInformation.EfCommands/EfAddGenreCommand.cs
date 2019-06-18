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
    public class EfAddGenreCommand : BaseEfCommand, IAddGenreCommand
    {
        public EfAddGenreCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateGenreDTO request)
        {

            if (_context.Genres.Any(x => x.Name.ToLower() == request.Name.ToLower().Trim()))
            {
                throw new EntityAlReadyExistException("Genre with this name already exist!");
            }


            _context.Genres.Add(new Genre
            {
               CreatedAt = DateTime.Now,
               Name = request.Name
            });

            _context.SaveChanges();
        }
    }
}
