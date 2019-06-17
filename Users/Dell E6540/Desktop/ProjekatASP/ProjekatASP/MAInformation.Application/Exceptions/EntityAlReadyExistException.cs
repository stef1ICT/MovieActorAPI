using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Exceptions
{
    public class EntityAlReadyExistException : Exception

    {
        public EntityAlReadyExistException(string message) : base(message)
        {

        }

    }
}
