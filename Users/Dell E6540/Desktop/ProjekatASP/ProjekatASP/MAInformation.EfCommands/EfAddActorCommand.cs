using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using MAInformation.Domain;

namespace MAInformation.EfCommands
{
    public class EfAddActorCommand : BaseEfCommand, IAddActorCommand
    {
        public EfAddActorCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateActorDTO request)
        {
            


            if(!_context.Genders.Any(g => g.Id  == request.GenderId))
            {
                throw new EntityNotFoundException("Gender");
            }

            _context.Actors.Add(new Actor
            {

                Country = request.Country,
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                GenderId = request.GenderId,
                Height = request.Height,
                Weight = request.Weight,
                HomeTown = request.HomeTown,
                LastName = request.LastName,
                Picture = request.Picture
                
            });
            _context.SaveChanges();
        }
    }
}
