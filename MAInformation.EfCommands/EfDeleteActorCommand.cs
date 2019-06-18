using MAInformation.Application.Commands;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfDeleteActorCommand : BaseEfCommand, IDeleteActorCommand
    {
        public EfDeleteActorCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            
            if(!_context.Actors.Any(a => a.Id == request))
            {
                throw new EntityNotFoundException("Actor");
            }

            var actor = _context.Actors.Find(request);

            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}
