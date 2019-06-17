using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Interfaces
{
   public interface ICommand<IRequest>
    {
        void Execute(IRequest request);
    }

    public interface ICommand<IRequest, IResponse>
    {
        IResponse Execute(IRequest request);
    }

   
}
