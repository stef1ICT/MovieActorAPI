using MAInformation.Application.DataTransfer;
using MAInformation.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Commands
{
  public  interface IUpdateMovieCommand : ICommand<CreateMovieDTO>
    {
    }
}
