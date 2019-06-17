using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Exceptions
{
    public class RelationAlreadyExistException : Exception
    {
        public RelationAlreadyExistException(string message) : base(message)
        {

        }
    }
}
