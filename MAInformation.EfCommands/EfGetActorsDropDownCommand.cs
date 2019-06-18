using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfGetActorsDropDownCommand : BaseEfCommand, IGetAllActors
    {
        public EfGetActorsDropDownCommand(MAInformationContext context) : base(context)
        {
        }

        public IEnumerable<ActorDropDownDTO> GetActors()
        {
            return  _context.Actors.Select(x => new ActorDropDownDTO
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName
            }).ToList();
        
        }
    }
}
