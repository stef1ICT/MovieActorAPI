using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
  public  class GetActorForMovie
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string HomeTown { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Picture { get; set; }
        public string NameInMovie { get; set; }
    }
}
