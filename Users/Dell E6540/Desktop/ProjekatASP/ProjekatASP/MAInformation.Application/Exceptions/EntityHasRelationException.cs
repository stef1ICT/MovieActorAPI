using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Exceptions
{
   public class EntityHasRelationException : Exception
    {
        public EntityHasRelationException(string poruka) : base (poruka)
        {

        }

    }
}
