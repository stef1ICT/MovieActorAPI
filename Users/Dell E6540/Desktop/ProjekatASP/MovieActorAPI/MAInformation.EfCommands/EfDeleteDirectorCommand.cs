using MAInformation.Application.Commands;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfDeleteDirectorCommand : BaseEfCommand, IDeleteDirectorCommand
    {
        public EfDeleteDirectorCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            
            if(!_context.Directors.Any(d => d.Id == request))
            {
                throw new EntityNotFoundException("Director");
            }

            var director = _context.Directors.Find(request);
            _context.Remove(director);

            _context.SaveChanges();
        }
    }
}
