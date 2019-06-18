using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.Exceptions
{
 public   class GenreHasMoviesException : Exception
    {
        public GenreHasMoviesException(string message) : base(message)
        {

        }
    }
}
