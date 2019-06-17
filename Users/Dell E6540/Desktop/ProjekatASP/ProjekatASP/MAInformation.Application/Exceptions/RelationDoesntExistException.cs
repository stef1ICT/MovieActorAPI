using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Exceptions
{
   public class RelationDoesntExistException : Exception
    {
        public RelationDoesntExistException(string message) : base(message)
        {

        }
    }
}
