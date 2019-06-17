using MAInformation.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Commands
{
    public interface IGetAllActors
    {
        IEnumerable<ActorDropDownDTO> GetActors();
    }
}
