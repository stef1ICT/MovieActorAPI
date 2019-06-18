using MAInformation.Application.Commands;
using MAInformation.Application.Exceptions;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfDeleteGenderCommand : BaseEfCommand, IDeleteGenderCommand
    {
        public EfDeleteGenderCommand(MAInformationContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var gender = _context.Genders.Find(request);

            if(gender == null)
            {
                throw new EntityNotFoundException("Gender doesn't exist.");
            }

            if (gender.Actors.Count > 0)
            {
                throw new EntityHasRelationException("Gender has relation.");
            }

            _context.Genders.Remove(gender);
            _context.SaveChanges();
        }
    }
}
