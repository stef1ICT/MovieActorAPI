using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
  public  class CreateMovieDTO
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="The field title must have minimum 3 characters")]
        public string Title { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The field description must have minimum 20 characters")]
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public double ImdbRating { get; set; }
        public int LanguageId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The field Image must have minimum 10 characters")]
        public string Image { get; set; }
        public int Duration { get; set; }
        public DateTime PremiereDate { get; set; }
    }
}
