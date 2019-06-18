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
    public class EfUpdateDirectorCommand : BaseEfCommand, IUpdateDirectorCommand
    {
        public EfUpdateDirectorCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateDirectorDTO request)
        {
            var director = _context.Directors.Find(request.Id);


            if(director == null)
            {
                throw new EntityNotFoundException("Director");
            }

            if(!_context.Genders.Any(g => g.Id == request.IdGender))
            {
                throw new EntityNotFoundException("Gender");
            }

            director.FirstName = request.FirstName;
            director.LastName = request.LastName;
            director.ModifiedAt = DateTime.Now;
            director.Country = request.Country;
            director.HomeTown = request.HomeTown;
            director.IdGender = request.IdGender;
            director.Picture = request.Picture;
            director.DateOfBirth = request.DateOfBirth;

            _context.SaveChanges();



        }
    }
}
