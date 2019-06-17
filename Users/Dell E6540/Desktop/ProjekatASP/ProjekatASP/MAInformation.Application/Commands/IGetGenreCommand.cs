using MAInformation.Application.DataTransfer;
using MAInformation.Application.Interfaces;
using MAInformation.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Commands
{
    public interface IGetGenreCommand : ICommand<GenreSearch, IEnumerable<GetGenreDTO>>
    {
    }
}
