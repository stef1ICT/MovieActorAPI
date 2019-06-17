using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.Application.Responses;
using MAInformation.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IGetActors _getActors;
        private IAddActorCommand _addActor;
        private IDeleteActorCommand _deleteActor;
        private IUpdateActorCommand _updateActor;

        public ActorController(IGetActors getActors, IAddActorCommand addActor, IDeleteActorCommand deleteActor, IUpdateActorCommand updateActor)
        {
            _getActors = getActors;
            _addActor = addActor;
            _deleteActor = deleteActor;
            _updateActor = updateActor;
        }






        // GET: api/Actor
        [HttpGet]
        public ActionResult<PagedResponse<GetActorDTO>> Get([FromQuery]ActorSearch dto )
        {
           try
            {
             var actors = _getActors.Execute(dto);
                return StatusCode(200, actors);
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
     /*   [Route("~/api/Actor/AddMovie")]
        [HttpGet] 
      public IActionResult Mudo()
        {
            return Ok();
        }**/
        // POST: api/Actor
        [HttpPost]
        public ActionResult Post([FromBody] CreateActorDTO dto)
        {
            
            try
            {
                _addActor.Execute(dto);
                return StatusCode(201);
            }catch(EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Actor/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateActorDTO dto)
        {
            
            try
            {
                dto.Id = id;
                _updateActor.Execute(dto);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
               return StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
                try
            {
                _deleteActor.Execute(id);

                return StatusCode(204);
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
