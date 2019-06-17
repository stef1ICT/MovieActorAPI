using MAInformation.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.EfCommands
{
 public abstract   class BaseEfCommand
    {
        protected MAInformationContext _context;

        protected BaseEfCommand(MAInformationContext context)
        {
            _context = context;
        }
    }
}
