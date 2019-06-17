using MAInformation.Application.DataTransfer;
using MAInformation.Application.Interfaces;
using MAInformation.Application.Responses;
using MAInformation.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Commands
{
  public  interface IGetActors : ICommand<ActorSearch, PagedResponse<GetActorDTO>>
    {
    }
}
