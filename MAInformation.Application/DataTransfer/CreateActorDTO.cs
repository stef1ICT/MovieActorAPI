using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
   public class CreateActorDTO 
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum 3 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum 3 characters.")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum 3 characters.")]
        public string Country { get; set; }
        public int GenderId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum 3 characters.")]
        public string HomeTown { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public double Height { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "This field must have minimum 10 characters.")]
        public string Picture { get; set; }
    }
}
