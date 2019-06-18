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
    public class EfCreateGenderCommand : BaseEfCommand, ICreateGenderCommand
    {
        public EfCreateGenderCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateGenderDTO request)
        {
          if(_context.Genders.Any(x => x.Name.ToLower() == request.Name.Trim().ToLower()))
            {
                throw new EntityAlReadyExistException("Gender Already exist");
            }

            _context.Genders.Add(new Gender { Name = request.Name });
            _context.SaveChanges();
        }
    }
}
