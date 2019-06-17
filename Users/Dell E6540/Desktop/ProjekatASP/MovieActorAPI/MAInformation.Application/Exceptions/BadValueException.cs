using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Exceptions
{
  public  class BadValueException : Exception
    {
        public BadValueException(string entity) : base($"{entity} bad value.")
        {

        }

        public BadValueException()
        {

        }
    }
}
