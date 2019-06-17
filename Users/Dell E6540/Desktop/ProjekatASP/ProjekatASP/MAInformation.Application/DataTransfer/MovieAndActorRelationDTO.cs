using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAInformation.Application.DataTransfer
{
   public class MovieAndActorRelationDTO
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Name in movie should has minimum 3 characters")]
        public string NameInMovie { get; set; }
    }
}
