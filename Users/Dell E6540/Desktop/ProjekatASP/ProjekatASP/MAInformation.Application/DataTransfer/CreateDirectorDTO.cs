using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
 public   class CreateDirectorDTO
    {

        public int? Id { get; set; }
        [Required(ErrorMessage ="This field First Name is required.")]
        [MinLength(3,ErrorMessage = "This field First Name must have minimum 3 characters.")]
        [RegularExpression("^[A-Z][a-z]{2,10}$", ErrorMessage ="This field isn't in good format.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field Last Name is required.")]
        [MinLength(3, ErrorMessage = "This field First Name must have minimum 3 characters.")]
        [RegularExpression("^[A-Z][a-z]{2,10}$", ErrorMessage = "This field isn't in good format.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field picture is required.")]
        [MinLength(3, ErrorMessage = "This field picture must have minimum 10 characters.")]
        [RegularExpression("^[A-Z][a-z]{2,10}$", ErrorMessage = "This field isn't in good format.")]
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdGender { get; set; }
        [Required(ErrorMessage = "This field country is required.")]
        [MinLength(3, ErrorMessage = "This field  country must have minimum 3 characters.")]
        [RegularExpression("^[A-Z][a-z]{2,10}$", ErrorMessage = "This field country isn't in good format.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field Home Town is required.")]
        [MinLength(3, ErrorMessage = "The field Home Town must have minimum 3 characters.")]
        [RegularExpression("^[A-Z][a-z]{2,10}$", ErrorMessage = "The field Home Town isn't in good format.")]
        public string HomeTown { get; set; }
    }
}
