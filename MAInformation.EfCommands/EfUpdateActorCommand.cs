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
    public class EfUpdateActorCommand :  BaseEfCommand ,IUpdateActorCommand
    {
        public EfUpdateActorCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateActorDTO request)
        {
            var actor = _context.Actors.Find(request.Id);

           if(actor == null)
            {
                 throw new EntityNotFoundException("Actor");
            }
           if(!_context.Genders.Any(g => g.Id == request.GenderId))
            {
                throw new EntityNotFoundException("Gender");
            }

           
            actor.FirstName = request.FirstName;
            actor.LastName = request.LastName;
            actor.Country = request.Country;
            actor.DateOfBirth = request.DateOfBirth;
            actor.HomeTown = request.HomeTown;
            actor.Weight = request.Weight;
            actor.Height = request.Height;
            actor.GenderId = request.GenderId;
            actor.Picture = request.Picture;
            actor.ModifiedAt = DateTime.Now;

            _context.SaveChanges();


        }
    }
}
