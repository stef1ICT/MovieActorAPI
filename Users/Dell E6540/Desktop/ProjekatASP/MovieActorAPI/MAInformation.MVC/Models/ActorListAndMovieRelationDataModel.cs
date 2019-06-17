using MAInformation.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAInformation.MVC.Models
{
    public class ActorListAndMovieRelationDataModel
    {
         public ActorListAndMovieRelationDataModel()
        {
            actors = new List<ActorDropDownDTO>();
        }
        public int MovieId { get; set; }
        public int? ActorId { get; set; }
        public string NameInMovie { get; set; }
        public List<ActorDropDownDTO>  actors { get; set; }
    }
}
