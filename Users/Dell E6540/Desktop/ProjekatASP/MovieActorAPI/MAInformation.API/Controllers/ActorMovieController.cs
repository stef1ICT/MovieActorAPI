using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorMovieController : ControllerBase
    {
        private IMovieActorRelationCommand _AddMovieActorRelation;
        private IDeleteMovieActorRelationCommand _deleteMovieactorRelation;

        public ActorMovieController(IMovieActorRelationCommand AddMovieActorRelation, IDeleteMovieActorRelationCommand deleteMovieactorRelation)
        {
            _AddMovieActorRelation = AddMovieActorRelation;
            _deleteMovieactorRelation = deleteMovieactorRelation;
        }



        // POST: api/ActorMovie/
        [HttpPost]
        public ActionResult Post([FromBody] MovieAndActorRelationDTO dto )
        {
           

            try
            {
                _AddMovieActorRelation.Execute(dto);
                return StatusCode(201);
            } catch(EntityAlReadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }  catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromBody]MovieActorDeleteDTO dto )
        {
            dto.MovieId = id;
            try
            {
                _deleteMovieactorRelation.Execute(dto);
                return NoContent();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
