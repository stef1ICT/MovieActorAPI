using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAInformation.EfCommands
{
    public class EfGetLanguagesCommand : BaseEfCommand, IGetLanguages
    {
        public EfGetLanguagesCommand(MAInformationContext context) : base(context)
        {
        }

        public IEnumerable<GetLanguageDTO> GetLanguages()
        {
            return _context.Languages.Select(x => new GetLanguageDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
