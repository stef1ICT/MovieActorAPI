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
    public class EfAddLanguageCommand : BaseEfCommand, IAddLanguageCommand
    {
        public EfAddLanguageCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateLanguageDTO request)
        {
            if(_context.Languages.Any(x => x.Name.ToLower() == request.Name.Trim().ToLower())) {
                throw new EntityAlReadyExistException("Language already exist.");
            }

            _context.Languages.Add(new Language
            {
                CreatedAt = DateTime.Now,
                Name = request.Name
            });
            _context.SaveChanges();
        }
    }
}
