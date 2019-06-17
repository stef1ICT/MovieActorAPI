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
    public class EfAddDirectorCommand : BaseEfCommand, IAddDirectorCommand
    {
        public EfAddDirectorCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(CreateDirectorDTO request)
        {
            if (!_context.Genders.Any(g => g.Id == request.IdGender))
            {
                throw new EntityNotFoundException("Gender");
            }



            _context.Directors.Add(new Director {

                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.Now,
                Country = request.Country,
                DateOfBirth = request.DateOfBirth,
                 IdGender = request.IdGender,
                 Picture = request.Picture,
                 HomeTown = request.HomeTown
            });

            _context.SaveChanges();
        }
    }
}
