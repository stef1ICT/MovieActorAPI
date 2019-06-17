using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfGetGenderCommand : BaseEfCommand, IGetGenderCommand
    {
        public EfGetGenderCommand(MAInformationContext context) : base(context)
        {
        }

        public IEnumerable<GetGenderDTO> genders()
        {
            return _context.Genders.Select(x => new GetGenderDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList(); 
        }
    }
}
