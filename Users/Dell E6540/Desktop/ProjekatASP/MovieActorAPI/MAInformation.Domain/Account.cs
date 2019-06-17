using System;
using System.Collections.Generic;
using System.Text;

namespace MAInformation.Domain
{
    public class Account : BaseEntity
    {
     
        public string  Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
